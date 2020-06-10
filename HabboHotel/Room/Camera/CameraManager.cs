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
            // décompresse les données json
            string jsonData = CameraUtils.InflateString(data);
            // analyser les plans du fichier json et les définir sur le rendu
            render.Planes = CameraUtils.ParsePlanes(jsonData);
            //analyser les images-objets du fichier json et les définir sur le rendu
            render.Sprites = CameraUtils.ParseSprites(jsonData);
            //analyser les filtres du fichier json et les définir sur le rendu
            render.Filters = CameraUtils.ParseFilters(jsonData);
            //rendre l'image
            render.Begin();
            //enregistrer l'image
            string filename  = CameraUtils.SaveImage(jsonData, render);
            //delete
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
