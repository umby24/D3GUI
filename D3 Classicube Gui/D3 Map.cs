using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression; // -- For GZip
using System.Drawing;

namespace D3_ISO_Viewer {
    class D3_Map {
        // -- D3 V1.0+ Map reader
        // -- Map size, spawn coords, and so on are stored in 'Config.txt'.
        // -- Actual block data is stored in Data-Layer.gz, which is in the format [byte]BlockID [byte]Metadata [short]Player 

        int Size_X;
        int Size_Y;
        int Size_Z; // -- Because this is just an image generator, I will not be needing all the info in config.txt
        string heightmaptime = "";
        public string time2d = "";
        public string time3d = "";
        public byte[] mapData;
        byte[,] heightMap;
        bool[, ,] isoMap;

        public Image generatedImage;
        Dictionary<byte, Color> colortable;

        public void readConfig(string fileName) {
            StreamReader fileReader = new StreamReader(fileName);

            do {
                string line = fileReader.ReadLine();

                if (!line.Contains("="))
                    continue;
                string setting = line.Substring(0, line.IndexOf("=") - 1);
                string value = line.Substring(line.IndexOf("=") + 2, line.Length - (line.IndexOf("=") + 2));

                switch (setting) {
                    case "Size_X":
                        Size_X = int.Parse(value);
                        break;
                    case "Size_Y":
                        Size_Y = int.Parse(value);
                        break;
                    case "Size_Z":
                        Size_Z = int.Parse(value);
                        break;
                    default:
                        continue;
                }
               
            } while (!fileReader.EndOfStream);
            fileReader.Close();
        }
        public void unzip(string filename) {
            // -- UnGZips our file, and loads it to memory.
            Stream mystream;
            FileStream infile = new FileStream(filename, FileMode.Open);

            mystream = new GZipStream(infile, CompressionMode.Decompress);

            MemoryStream output = new MemoryStream();

            byte[] buffer = new byte[1024];
            while (true) {
                int readbytes = mystream.Read(buffer, 0, 1024);

                if (readbytes == 0)
                    break;

                output.Write(buffer, 0, readbytes);
            }
            mystream.Close();
            mapData = output.ToArray();
            output.Close();

        }
        public int getBlockID(int x, int y, int z) {
            if ((x >= 0 && y >= 0 && z >= 0) && (Size_X > x && Size_Y > y && Size_Z > z)) {
                int index = (z * Size_Y + y) * Size_X + x; // -- (Y * Size_Z + Z) * Size_X + x
                return mapData[(index * 4)];
            } else {
                return 1;
            }
        }
        public void generate_Heightmap() {
            // -- Used for shadows, and for 2D images.
            // -- Start at the highest Z value, and work your way down until you hit a block. For each column.
            DateTime mytime = DateTime.Now;

            heightMap = new byte[Size_X, Size_Y];

            for (int ix = 0; ix <= (Size_X - 1); ix++) {
                for (int iy = 0; iy <= (Size_Y - 1); iy++) {
                    for (int iz = (Size_Z - 1); iz > -1; iz--) {
                        int blockID = getBlockID(ix, iy, iz);
                        if (ix == 63) {
                            ix = 63;
                        }
                        if (blockID != 0) {
                            // -- Found something, plot it.
                            heightMap[ix, iy] = (byte)blockID;
                            break;
                        }
                    }
                }
            }
            DateTime done = DateTime.Now;
            heightmaptime = (done.TimeOfDay - mytime.TimeOfDay).ToString();
        }
        public void loadBlockColors(string blocktext) {
            // -- Load block colors from Block.txt, into a dictionary!
            colortable = new Dictionary<byte, Color>();
            StreamReader fileReader = new StreamReader(blocktext);
            string blockid = "";
            Color blockColor = Color.Transparent;

            do {
                string line = fileReader.ReadLine();

                if (line.Contains("[") && line.Contains("]")) {
                    if (blockid != "")
                        colortable.Add((byte)int.Parse(blockid), blockColor);

                    blockid = line.Substring(1, line.Length - 2);
                    blockColor = Color.Transparent;
                    continue;
                }
                if (!line.Contains("="))
                    continue;
                string setting = line.Substring(0, line.IndexOf("=") - 1);
                string value = line.Substring(line.IndexOf("=") + 2, line.Length - (line.IndexOf("=") + 2));
                
                switch (setting) {
                    case "Color_Overview":
                        if (value != "-1") {
                            string hexValue = int.Parse(value).ToString("X"); // Swap last, with the center.
                            hexValue = hexValue.PadLeft(6, '0');
                            hexValue = hexValue.Substring(4, 2) + hexValue.Substring(2, 2) + hexValue.Substring(0, 2);

                            blockColor = ColorTranslator.FromHtml("#" + hexValue);
                        } else { blockColor = Color.Transparent; }
                        break;
                    default:
                        continue;
                }

            } while (!fileReader.EndOfStream);
            fileReader.Close();
        }
        public void generate_2D() {
            DateTime Start = DateTime.Now;
            Bitmap thismap = new Bitmap(Size_X * 4, Size_Y * 4);
            Graphics thisg = Graphics.FromImage((Image)thismap);
            int timex = 0;
            int timey = 0;
            for (int x = 0; x <= (Size_X - 1); x++) {
                for (int y = 0; y <= (Size_Y - 1); y++) {
                    thisg.FillRectangle(new SolidBrush(colortable[heightMap[x,y]]),new Rectangle(x + timex, y + timey,6,6));
                    timey += 3;
                }
                timex += 3;
                timey = 0;
            }
            DateTime Finish = DateTime.Now;
            time2d = (Finish.TimeOfDay - Start.TimeOfDay).ToString();
            generatedImage = (Image)thismap;
        }
        public void generate_Isomap() {
            for (int ix = 0; ix <= (Size_X - 1); ix++) {
                for (int iy = 0; iy <= (Size_Y - 1); iy++) {
                    for (int iz = 0; iz <= (Size_Z - 1); iz++) {
                        //if (getBlockID(
                    }
                }
            }
        }
        public bool render(int x, int y, int z) {
            if (x == Size_X - 1 || y == Size_Y - 1)
                return true;

            if (getBlockID(x + 1, y, z) != 0 && getBlockID(x, y + 1, z) != 0 && getBlockID(x, y, z + 1) != 0 && getBlockID(x - 1, y, z) != 0 && getBlockID(x, y - 1, z) != 0 && getBlockID(x, y, z - 1) != 0 && getBlockID(x + 1, y, z + 1) != 0 && getBlockID(x - 1, y, z - 1) != 0 && getBlockID(x, y + 1, z + 1) != 0 && getBlockID(x, y - 1, z - 1) != 0) {
                return false;
            } else {
                return true;
            }
        }

        public void generate_iso() {
            DateTime Start = DateTime.Now;
            // X = ix * chunk_size
            // X,Y,Z = ChunkSize, CHunksize, Size_Z
            // Draw_Chunk(X, Y, #Chunk_Size, #Chunk_Size, Map_Data\Size_Z)
            Bitmap mybitmap = new Bitmap((Size_X + Size_Y), (Size_X + Size_Y + Size_Z));
            Graphics thisg = Graphics.FromImage((Image)mybitmap);
            int timex = 0;
            int timey = 0;

            for (int ix = 0; ix <= (Size_X - 1); ix++) {
                int X = ix;
                for (int iy = 0; iy <= (Size_Y - 1); iy++) {
                    int Y = iy;
                    for (int iz = 0; iz <= (Size_Z - 1); iz++) {
                        int Z = iz;
                        if (render(ix, iy, iz) == false)
                            continue;
                        int Image_X = (Size_Y + ix - iy);
                        int Image_Y = (Size_Z + iy + ix - iz);
                        
                        if (X >= 0 && X < Size_X && Y >= 0 && Y < Size_Y && Z >= 0 && Z < Size_Z) {
                            int block = getBlockID(X, Y, Z);
                           
                            Color blockColor = colortable[(byte)block];
                            if (blockColor != Color.Transparent) {
                                //blockColor = Color_Darken(blockColor,));
                                mybitmap.SetPixel(Image_X, Image_Y, Color_Darken(blockColor, (float)0.5));
                                mybitmap.SetPixel(Image_X - 1, Image_Y + 1, Color_Darken(blockColor, (float).7));
                                mybitmap.SetPixel(Image_X, Image_Y + 1, blockColor);
                               // thisg.FillRectangle(new SolidBrush(Color_Darken(blockColor,(float)0.5)), new Rectangle((Image_X + timex), (Image_Y + timey), 6, 6));
                            }
                        }
                    }
                    timey += 6;
                    
                }
                timex += 6;
                timey = 0;
            }
            DateTime done = DateTime.Now;
            time3d = (done.TimeOfDay - Start.TimeOfDay).ToString();
            generatedImage = (Image)mybitmap;
        }
        public Color Color_Darken(Color color, float factor) {
            return Color.FromArgb((int)(color.R * factor), (int)(color.G * factor), (int)(color.B * factor));
        }
    }
}
