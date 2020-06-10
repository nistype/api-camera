using CameraAPI;
using log4net;
using Plus.HabboHotel.Users;
using System;
using System.Collections.Generic;

namespace Plus.HabboHotel.Rooms.Camera
{
    public class CameraManager
    {
        private static readonly ILog log = LogManager.GetLogger("Plus.HabboHotel.Rooms.CameraManager");
        private Dictionary<int, String> _photos_preview;

        public void Init()
        {
            CameraUtils.LoadConfiguration();
            _photos_preview = new Dictionary<int, String>();
            log.Info("Camera Manager -> LOADED");
        }

        public void RenderImage(byte[] data, bool isThumbnail, Habbo habbo)
        {
            CameraRender render = new CameraRender(isThumbnail);
            //decompress the json data
            string jsonData = CameraUtils.InflateString(data);
            //parsing the planes from the json file and setting them to the render
            render.Planes = CameraUtils.ParsePlanes(jsonData);
            //parsing the sprites from the json file and setting them to the render
            render.Sprites = CameraUtils.ParseSprites(jsonData);
            //parsing the filters from the json file and setting them to the render
            render.Filters = CameraUtils.ParseFilters(jsonData);
            //rendering the image
            render.Begin();
            //saving the image
            string filename  = CameraUtils.SaveImage(jsonData, render);
            //disposing the garbage!
            render.Dispose();
            
            if (!isThumbnail)
            {
                if (_photos_preview.ContainsKey(habbo.Id))
                    _photos_preview.Remove(habbo.Id);
                _photos_preview.Add(habbo.Id, filename);
            }
        }

        public String GetPhotoForHabbo(Habbo habbo)
        {
            _photos_preview.TryGetValue(habbo.Id, out string value);
            return value;
        }
    }
}