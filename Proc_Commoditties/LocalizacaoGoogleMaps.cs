using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Proc_Commoditties
{

    public class ObjectMap
    {
        public string distancia { get; set; }
        public string duracao { get; set; }
        public string origem { get; set; }
        public string destino { get; set; }

        public string pOrigem { get; set; }
        public string pDestino { get; set; }
        public string web_browser_navigate { get; set; }
        public string id_origem { get; set; }
        public string id_destino { get; set; }
        public bool pai { get; set; }
        public decimal camada { get; set; }
        public List_ObjectMap list { get; set; } = new List_ObjectMap();
        public ObjectMap()
        {
            list = new List_ObjectMap();
            pai = false;
            distancia = string.Empty;
            id_destino = string.Empty;
            id_origem = string.Empty;
            camada = decimal.Zero;
            duracao = string.Empty;
            origem = string.Empty;
            destino = string.Empty;
            pOrigem = string.Empty;
            pDestino = string.Empty;
            web_browser_navigate = "http://maps.google.com/maps/dir/{0}/{1}";


        }
    }
    public class List_ObjectMap : List<ObjectMap> { }


    public class Navigate
    {
        public string origem = string.Empty;
        public string destino = string.Empty;

        public Navigate()
        {

        }  


        public ObjectMap BuscarLocalizacao(string pOrigem, string pDestino)
        {
            ObjectMap obj = new ObjectMap();
            try
            {
                double distancia, duracao; 
                if (Navigated(pOrigem, pDestino, out distancia, out duracao))
                {
                    obj.distancia = string.Format("{0} m ({1:n2} km)", distancia, distancia / 1000);
                    obj.duracao = string.Format("{0} seg ({1:n2} min)", duracao, duracao / 60);
                    obj.origem = this.origem;
                    obj.destino = this.destino;
                    // webBrowser1.Navigate(string.Format("http://maps.google.com/maps/dir/{0}/{1}", pOrigem, pDestino));
                }
                else
                {
                    throw new Exception("Não foi possível encontrar um caminho entre a origem e o destino.");
                }
            }
            catch { }
            finally { }
            return obj;
        }


        private bool Navigated(string pOrigem, string pDestino, out double distancia, out double duracao)
        {
            bool sucesso = false;
            distancia = duracao = 0;

            string or = string.Empty;
            string de = string.Empty;
            try
            {
                string url = string.Format(
                    "http://maps.googleapis.com/maps/api/directions/json?origin={0}&destination={1}&sensor=false",
                    pOrigem, pDestino);
                System.Net.WebRequest request = System.Net.HttpWebRequest.Create(url);
                System.Net.WebResponse response = request.GetResponse();
                using (var reader = new System.IO.StreamReader(response.GetResponseStream()))
                {
                    System.Web.Script.Serialization.JavaScriptSerializer parser = new System.Web.Script.Serialization.JavaScriptSerializer();
                    string responseString = reader.ReadToEnd();
                    RootObject responseData = parser.Deserialize<RootObject>(responseString);
                    if (responseData != null)
                    {
                        double distanciaRetornada = responseData.routes.Sum(r => r.legs.Sum(l => l.distance.value));
                        double duracaoRetornada = responseData.routes.Sum(r => r.legs.Sum(l => l.duration.value));

                        responseData.routes.ForEach(p => { p.legs.ForEach(o => { this.destino = o.end_address.ToString(); }); });
                        responseData.routes.ForEach(p => { p.legs.ForEach(o => { this.origem = o.start_address.ToString(); }); });

                        if (distanciaRetornada != 0)
                        {
                            sucesso = true;
                            distancia = distanciaRetornada;
                            duracao = duracaoRetornada; 
                        }
                    }
                }
            }
            catch { }
            finally { }

            return sucesso;
        }
    }








    public class GeocodedWaypoint
    {
        public string geocoder_status { get; set; }
        public bool partial_match { get; set; }
        public string place_id { get; set; }
        public List<string> types { get; set; }
    }

    public class Northeast
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Southwest
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Bounds
    {
        public Northeast northeast { get; set; }
        public Southwest southwest { get; set; }
    }

    public class Distance
    {
        public string text { get; set; }
        public int value { get; set; }
    }

    public class Duration
    {
        public string text { get; set; }
        public int value { get; set; }
    }

    public class EndLocation
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class StartLocation
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Distance2
    {
        public string text { get; set; }
        public int value { get; set; }
    }

    public class Duration2
    {
        public string text { get; set; }
        public int value { get; set; }
    }

    public class EndLocation2
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Polyline
    {
        public string points { get; set; }
    }

    public class StartLocation2
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Step
    {
        public Distance2 distance { get; set; }
        public Duration2 duration { get; set; }
        public EndLocation2 end_location { get; set; }
        public string html_instructions { get; set; }
        public Polyline polyline { get; set; }
        public StartLocation2 start_location { get; set; }
        public string travel_mode { get; set; }
        public string maneuver { get; set; }
    }

    public class Leg
    {
        public Distance distance { get; set; }
        public Duration duration { get; set; }
        public string end_address { get; set; }
        public EndLocation end_location { get; set; }
        public string start_address { get; set; }
        public StartLocation start_location { get; set; }
        public List<Step> steps { get; set; }
        public List<object> via_waypoint { get; set; }
    }

    public class OverviewPolyline
    {
        public string points { get; set; }
    }

    public class Route
    {
        public Bounds bounds { get; set; }
        public string copyrights { get; set; }
        public List<Leg> legs { get; set; }
        public OverviewPolyline overview_polyline { get; set; }
        public string summary { get; set; }
        public List<object> warnings { get; set; }
        public List<object> waypoint_order { get; set; }
    }

    public class RootObject
    {
        public List<GeocodedWaypoint> geocoded_waypoints { get; set; }
        public List<Route> routes { get; set; }
        public string status { get; set; }
    }
}
