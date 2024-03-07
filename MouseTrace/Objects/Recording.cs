using Newtonsoft.Json;
using System.Buffers.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Text.Json;

namespace MouseTrace.Objects
{
    public class Recording : RecordingVariables
    {
        private List<RecordingVariables> lista;

        private bool started = false;

        private int _position = 0;

        Screen screen;

        public Recording()
        {
            lista = new List<RecordingVariables>();
        }

        #region Private Method
        private void Run()
        {
            while (started)
            {
                var position = GetMousePosition();
                var size = GetScreenSize();
                var bounds = GetScreenBounds();

                var bitmap = GetScreenImage(bounds.Item3, bounds.Item4, bounds.Item5, bounds.Item6);

                lista.Add(
                    new RecordingVariables
                    {
                        image = bitmap,
                        cursorX = position.Item1,
                        cursorY = position.Item2,
                        screenSizeX = size.Item1,
                        screenSizeY = size.Item2,
                        screenBoundLeft = bounds.Item1,
                        screenBoundTop = bounds.Item2,
                        screenBoundWidth = bounds.Item3,
                        screenBoundHeight = bounds.Item4,
                        screenLocation = bounds.Item5,
                        screenSize = bounds.Item6
                    });

                Thread.Sleep(1000);
            }
        }

        private Bitmap GetScreenImage(int screenBoundWidth, int screenBoundHeight, Point screenLocation, Size screenSize)
        {
            Bitmap screenshot = new Bitmap(Convert.ToInt32(screenBoundWidth), Convert.ToInt32(screenBoundHeight));
            using (Graphics g = Graphics.FromImage(screenshot))
            {
                g.CopyFromScreen(screenLocation, Point.Empty, screenSize);

            }

            return screenshot;
        }

        private Bitmap GetScreenImageToChoose(int position)
        {
            Screen _sc = Screen.AllScreens[position];

            Bitmap captureBitmap = new Bitmap(_sc.Bounds.Width, _sc.Bounds.Height, PixelFormat.Format32bppArgb);
            Rectangle captureRectangle = _sc.Bounds;
            Graphics captureGraphics = Graphics.FromImage(captureBitmap);
            captureGraphics.CopyFromScreen(captureRectangle.Left, captureRectangle.Top, 0, 0, captureRectangle.Size);
            
            return captureBitmap;
        }

        private (int, int) GetMousePosition()
        {
            Point cursorPos = Cursor.Position;

            return (cursorPos.X, cursorPos.Y);
        }

        private (int, int, int, int, Point, Size) GetScreenBounds()
        {
            return (screen.Bounds.Left, screen.Bounds.Top, screen.Bounds.Width, screen.Bounds.Height, screen.Bounds.Location, screen.Bounds.Size);
        }

        private (int, int) GetScreenSize()
        {
            Rectangle captureRectangle = screen.Bounds;

            return (captureRectangle.Size.Width, captureRectangle.Size.Height);
        }
        #endregion

        #region Public Methods
        public void start(int position = 0)
        {
            started = true;

            _position = position;

            screen = Screen.AllScreens[position];

            Task task = Task.Run((Action)Run);
        }

        public Screen[] GetScreens()
        {
            return Screen.AllScreens;
        }

        public Bitmap GetScreenImageByPosition(int screenPosition)
        {
            return GetScreenImageToChoose(screenPosition);
        }

        public int GetCountRecordings()
        {
            return lista.Count;
        }

        public void stop()
        {
            started = false;
        }

        public bool SaveJsonFile(string path)
        {
            try
            {
                var json = JsonConvert.SerializeObject(lista);

                using (FileStream fs = File.Create(path))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(json);
                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }

                return true;
            }

            catch
            {
                return false;
            }
        }

        public RecordingVariables GetRecordingPosition (int position)
        {
            if (position >= 0 && position < lista.Count)
            {
                return lista[position];
            }

            return null;
        }

        public List<RecordingVariables> GetRecordings()
        { return lista; }

        public void reset()
        {
            lista.Clear();
        }

        public void load(string path)
        {
            string json = File.ReadAllText(path);
            lista = JsonConvert.DeserializeObject<List<RecordingVariables>>(json);

            foreach(var _item in lista)
            {
                // Convert Base64 String to byte[]
                byte[] imageBytes = Convert.FromBase64String(_item.imageBase64);
                MemoryStream ms = new MemoryStream(imageBytes, 0,
                  imageBytes.Length);

                // Convert byte[] to Image
                ms.Write(imageBytes, 0, imageBytes.Length);
                Image image = Image.FromStream(ms, true);

                _item.image = (Bitmap)image;
            }
        }
        #endregion
    }

    public class RecordingVariables
    {
        private Bitmap _image;

        [JsonIgnore]
        public Bitmap image
        {
            get
            {
                return _image;
            }
            set
            { 
                _image = value;
                ImageConverter converter = new ImageConverter();
                imageBase64 = Convert.ToBase64String((byte[])converter.ConvertTo(value, typeof(byte[])));
            }
        }
        public string imageBase64 { get; set; }
        public long cursorX { get; set; }
        public long cursorY { get; set; }
        public long screenSizeX { get; set; }
        public long screenSizeY { get; set; }
        public long screenBoundLeft { get; set; }
        public long screenBoundTop { get; set; }
        public long screenBoundWidth { get; set; }
        public long screenBoundHeight { get; set; }
        public Point screenLocation { get; set; }
        public Size screenSize { get; set; }
    }
}
