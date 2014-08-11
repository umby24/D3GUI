// -- For GZip
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Compression;

namespace D3_Classicube_Gui {
    class D3Map {
        // -- D3 V1.0+ Map reader
        // -- Map size, spawn coords, and so on are stored in 'Config.txt'.
        // -- Actual block data is stored in Data-Layer.gz, which is in the format [byte]BlockID [byte]Metadata [short]Player 

        int _sizeX;
        int _sizeY;
        int _sizeZ; // -- Because this is just an image generator, I will not be needing all the info in config.txt
        private string _heightmaptime = "";
        public string Time2D = "";
        public string Time3D = "";
        public byte[] MapData;
        byte[,] _heightMap;

        public Image GeneratedImage;
        Dictionary<byte, Color> _colortable;

        public string Heightmaptime
        {
            get { return _heightmaptime; }
            set { _heightmaptime = value; }
        }

        public void ReadConfig(string fileName) {
            var fileReader = new StreamReader(fileName);

            do {
                var line = fileReader.ReadLine();

                if (line != null && !line.Contains("="))
                    continue;

                if (line == null) 
                    continue;

                var setting = line.Substring(0, line.IndexOf("=") - 1);
                var value = line.Substring(line.IndexOf("=") + 2, line.Length - (line.IndexOf("=") + 2));

                switch (setting) {
                    case "Size_X":
                        _sizeX = int.Parse(value);
                        break;
                    case "Size_Y":
                        _sizeY = int.Parse(value);
                        break;
                    case "Size_Z":
                        _sizeZ = int.Parse(value);
                        break;
                    default:
                        continue;
                }
            } while (!fileReader.EndOfStream);
            fileReader.Close();
        }

        public void Unzip(string filename) {
            // -- UnGZips our file, and loads it to memory.
            var infile = new FileStream(filename, FileMode.Open);

            Stream mystream = new GZipStream(infile, CompressionMode.Decompress);

            var output = new MemoryStream();

            var buffer = new byte[1024];
            while (true) {
                var readbytes = mystream.Read(buffer, 0, 1024);

                if (readbytes == 0)
                    break;

                output.Write(buffer, 0, readbytes);
            }
            mystream.Close();
            MapData = output.ToArray();
            output.Close();

        }
        public int GetBlockId(int x, int y, int z)
        {
            if ((x >= 0 && y >= 0 && z >= 0) && (_sizeX > x && _sizeY > y && _sizeZ > z)) {
                var index = (z * _sizeY + y) * _sizeX + x; // -- (Y * Size_Z + Z) * Size_X + x
                return MapData[(index * 4)];
            }
            return 1;
        }

        public void generate_Heightmap() {
            // -- Used for shadows, and for 2D images.
            // -- Start at the highest Z value, and work your way down until you hit a block. For each column.
            var mytime = DateTime.Now;

            _heightMap = new byte[_sizeX, _sizeY];

            for (var ix = 0; ix < _sizeX; ix++) {
                for (var iy = 0; iy < _sizeY; iy++) {
                    for (var iz = (_sizeZ - 1); iz > -1; iz--) {
                        var blockId = GetBlockId(ix, iy, iz);
                        if (ix == 63) {
                            ix = 63;
                        }
                        if (blockId != 0) {
                            // -- Found something, plot it.
                            _heightMap[ix, iy] = (byte)blockId;
                            break;
                        }
                    }
                }
            }
            var done = DateTime.Now;
            Heightmaptime = (done.TimeOfDay - mytime.TimeOfDay).ToString();
        }
        public void LoadBlockColors(string blocktext) {
            // -- Load block colors from Block.txt, into a dictionary!
            _colortable = new Dictionary<byte, Color>();
            var fileReader = new StreamReader(blocktext);
            var blockid = "";
            var blockColor = Color.Transparent;

            do {
                var line = fileReader.ReadLine();

                if (line != null && (line.Contains("[") && line.Contains("]"))) {
                    if (blockid != "")
                        _colortable.Add((byte)int.Parse(blockid), blockColor);

                    blockid = line.Substring(1, line.Length - 2);
                    blockColor = Color.Transparent;
                    continue;
                }
                if (line != null && !line.Contains("="))
                    continue;

                if (line == null) 
                    continue;

                var setting = line.Substring(0, line.IndexOf("=") - 1);
                var value = line.Substring(line.IndexOf("=") + 2, line.Length - (line.IndexOf("=") + 2));
                
                switch (setting) {
                    case "Color_Overview":
                        if (value != "-1") {
                            var hexValue = int.Parse(value).ToString("X"); // Swap last, with the center.
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
            var start = DateTime.Now;
            var thismap = new Bitmap(_sizeX * 4, _sizeY * 4);
            var thisg = Graphics.FromImage(thismap);
            var timex = 0;
            var timey = 0;
            for (var x = 0; x <= (_sizeX - 1); x++) {
                for (var y = 0; y <= (_sizeY - 1); y++) {
                    thisg.FillRectangle(new SolidBrush(_colortable[_heightMap[x,y]]),new Rectangle(x + timex, y + timey,6,6));
                    timey += 3;
                }
                timex += 3;
                timey = 0;
            }
            var finish = DateTime.Now;
            Time2D = (finish.TimeOfDay - start.TimeOfDay).ToString();
            GeneratedImage = thismap;
        }

        public bool Render(int x, int y, int z) {
            if (x == _sizeX - 1 || y == _sizeY - 1)
                return true;

            return GetBlockId(x + 1, y, z) == 0 || GetBlockId(x, y + 1, z) == 0 || GetBlockId(x, y, z + 1) == 0 || GetBlockId(x - 1, y, z) == 0 || GetBlockId(x, y - 1, z) == 0 || GetBlockId(x, y, z - 1) == 0 || GetBlockId(x + 1, y, z + 1) == 0 || GetBlockId(x - 1, y, z - 1) == 0 || GetBlockId(x, y + 1, z + 1) == 0 || GetBlockId(x, y - 1, z - 1) == 0;
        }

        public void generate_iso() {
            var start = DateTime.Now;
            // X = ix * chunk_size
            // X,Y,Z = ChunkSize, CHunksize, Size_Z
            // Draw_Chunk(X, Y, #Chunk_Size, #Chunk_Size, Map_Data\Size_Z)
            var mybitmap = new Bitmap((_sizeX + _sizeY), (_sizeX + _sizeY + _sizeZ));
            Graphics.FromImage((Image)mybitmap);

            for (var ix = 0; ix < _sizeX; ix++) {
                var x = ix;
                for (var iy = 0; iy < _sizeY; iy++) {
                    var y = iy;
                    for (var iz = 0; iz < _sizeZ; iz++) {
                        var z = iz;
                        if (Render(ix, iy, iz) == false)
                            continue;
                        var imageX = (_sizeY + ix - iy);
                        var imageY = (_sizeZ + iy + ix - iz);
                        
                        if (x >= 0 && x < _sizeX && y >= 0 && y < _sizeY && z >= 0 && z < _sizeZ) {
                            var block = GetBlockId(x, y, z);
                           
                            var blockColor = _colortable[(byte)block];
                            if (blockColor != Color.Transparent) {
                                //blockColor = Color_Darken(blockColor,));
                                mybitmap.SetPixel(imageX, imageY, Color_Darken(blockColor, (float)0.5));
                                mybitmap.SetPixel(imageX - 1, imageY + 1, Color_Darken(blockColor, (float).7));
                                mybitmap.SetPixel(imageX, imageY + 1, blockColor);
                               // thisg.FillRectangle(new SolidBrush(Color_Darken(blockColor,(float)0.5)), new Rectangle((Image_X + timex), (Image_Y + timey), 6, 6));
                            }
                        }
                    }
                }
            }
            var done = DateTime.Now;
            Time3D = (done.TimeOfDay - start.TimeOfDay).ToString();
            GeneratedImage = mybitmap;
        }
        public Color Color_Darken(Color color, float factor) {
            return Color.FromArgb((int)(color.R * factor), (int)(color.G * factor), (int)(color.B * factor));
        }
    }
}
