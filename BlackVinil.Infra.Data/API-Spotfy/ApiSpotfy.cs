using BlackVinil.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace BlackVinil.Infra.Data.API_Spotfy
{
    class ApiSpotfy
    {
        private static Token token = null;

        public IEnumerable<Disco> GetDiscos(GeneroMusical genero)
        {
            DiscoSpotfy discoSpotfy = GetDiscosSpotify(genero);
            if (discoSpotfy != null)
            {
                List<Disco> lstDisco = new List<Disco>();
                foreach (Item iten in discoSpotfy.albums.items.OrderBy(d => d.name))
                {
                    Disco disco = new Disco
                    {
                        Id = iten.id,
                        Nome = iten.name,
                        Ano = iten.release_date.Substring(0, 4),
                        href = iten.href,
                        Imagem = iten.images.Select(s => s.url).Last(),
                        //Preco = CashBack.Preco(genero),
                        //CashBack = CashBack.ValorDia(genero),
                        Genero = genero

                    };

                    lstDisco.Add(disco);
                }

                return lstDisco;
            }
            else
            {
                Disco disco = new Disco { Id = "NãoDefinido" };
                List<Disco> ret = new List<Disco>();
                ret.Add(disco);
                return ret;
            }
        }

        public Disco GetDiscosId(string id, GeneroMusical genero)
        {            
            Item item = GetDiscosSpotifyId(id, genero);

            if (item != null)
            {
                Disco disco = new Disco();

                disco.Id = item.id;
                disco.Nome = item.name;
                disco.Ano = item.release_date.Substring(0, 4);
                disco.href = item.href;
                disco.Imagem = item.images.Select(s => s.url).Last();
                //disco.Preco = CashBack.Preco(genero);
                //disco.CashBack = CashBack.ValorDia(genero);
                disco.Genero = genero;

                return disco;
            }
            else
            {
                Disco disco = new Disco { Id = "NãoDefinido" };
                //List<Disco> ret = new List<Disco>();
                //ret.Add(disco);
                return disco;
            }
        }

        private DiscoSpotfy GetDiscosSpotify(GeneroMusical genero)
        {
            Token _token = GetToken();
            string limit = "50";
            if (_token == null || string.IsNullOrEmpty(genero.ToString()))
            {
                return null;
            }
            //_token.access_token = "BQDxT-BwWogYb8i9EJdZf-zM_UFJKWCl6ulDN6n37iGyU3dJUSCDOBI4KfWwXuQO3Qrj6_u9IlGc6Yc_k2A";
            //_token.expires_in = 3600;
            //_token.token_type = "Bearer";

            var requisicaoWeb = WebRequest.CreateHttp($"https://api.spotify.com/v1/search?q={genero.ToString().ToLower()}&type=album&limit={limit}&offset=1");
            requisicaoWeb.Method = "GET";
            requisicaoWeb.ContentType = "application/x-www-form-urlencoded";
            requisicaoWeb.Headers.Add("Authorization", string.Format("{0} {1}", _token.token_type, _token.access_token));
            try
            {
                using (var resposta = requisicaoWeb.GetResponse())
                {
                    if (resposta.ContentLength > 0)
                    {
                        var streamDados = resposta.GetResponseStream();
                        StreamReader reader = new StreamReader(streamDados);
                        object objResponse = reader.ReadToEnd();

                        DiscoSpotfy post = JsonConvert.DeserializeObject<DiscoSpotfy>(objResponse.ToString());
                        return post;
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return null;

        }

        private Item GetDiscosSpotifyId(string id, GeneroMusical genero)
        {
            Token _token = GetToken();
            if (_token == null || string.IsNullOrEmpty(id.ToString()))
            {
                return null;
            }

            var requisicaoWeb = WebRequest.CreateHttp($"https://api.spotify.com/v1/albums/{id}");
            requisicaoWeb.Method = "GET";
            requisicaoWeb.ContentType = "application/x-www-form-urlencoded";
            requisicaoWeb.Headers.Add("Authorization", string.Format("{0} {1}", _token.token_type, _token.access_token));
            try
            {
                using (var resposta = requisicaoWeb.GetResponse())
                {
                    if (resposta.ContentLength > 0)
                    {
                        var streamDados = resposta.GetResponseStream();
                        StreamReader reader = new StreamReader(streamDados);
                        object objResponse = reader.ReadToEnd();

                        Item post = JsonConvert.DeserializeObject<Item>(objResponse.ToString());
                        return post;
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return null;
        }

        private Token GetToken()
        {
            try
            {
                if (token == null || token.Time < DateTime.Now)
                {
                    string dadosPOST = "client_id=43abf0d1407640b6872f291b4d81db8b";
                    dadosPOST = dadosPOST + "&client_secret=0a1db84e10d0496386e6471e286705a6";
                    dadosPOST = dadosPOST + "&grant_type=client_credentials";

                    var dados = Encoding.UTF8.GetBytes(dadosPOST);
                    var requisicaoWeb = WebRequest.CreateHttp("https://accounts.spotify.com/api/token");
                    requisicaoWeb.Method = "POST";
                    requisicaoWeb.ContentType = "application/x-www-form-urlencoded";
                    requisicaoWeb.ContentLength = dados.Length;
                    using (var stream = requisicaoWeb.GetRequestStream())
                    {
                        stream.Write(dados, 0, dados.Length);
                        stream.Close();
                    }
                    //ler e exibir a resposta
                    using (var resposta = requisicaoWeb.GetResponse())
                    {
                        if (resposta.ContentLength > 0)
                        {
                            var streamDados = resposta.GetResponseStream();
                            StreamReader reader = new StreamReader(streamDados);
                            object objResponse = reader.ReadToEnd();
                            token = JsonConvert.DeserializeObject<Token>(objResponse.ToString());
                            token.Time = DateTime.Now.AddSeconds(token.expires_in);

                        }
                    }

                }
            }
            catch (Exception ex)
            {
                token = null;
            }

            return token;

        }


        class Token
        {
            public string access_token { get; set; }
            public string token_type { get; set; }
            public int expires_in { get; set; }
            public DateTime Time { get; set; }
        }

        public class ExternalUrls
        {
            public string spotify { get; set; }
        }

        public class Artist
        {
            public ExternalUrls external_urls { get; set; }
            public string href { get; set; }
            public string id { get; set; }
            public string name { get; set; }
            public string type { get; set; }
            public string uri { get; set; }
        }

        public class ExternalUrls2
        {
            public string spotify { get; set; }
        }

        public class Image
        {
            public int height { get; set; }
            public string url { get; set; }
            public int width { get; set; }
        }

        public class Item
        {
            public string album_type { get; set; }
            public List<Artist> artists { get; set; }
            public List<string> available_markets { get; set; }
            public ExternalUrls2 external_urls { get; set; }
            public string href { get; set; }
            public string id { get; set; }
            public List<Image> images { get; set; }
            public string name { get; set; }
            public string release_date { get; set; }
            public string release_date_precision { get; set; }
            public int total_tracks { get; set; }
            public string type { get; set; }
            public string uri { get; set; }
        }

        public class Albums
        {
            public string href { get; set; }
            public List<Item> items { get; set; }
            public int limit { get; set; }
            public string next { get; set; }
            public int offset { get; set; }
            public object previous { get; set; }
            public int total { get; set; }
        }

        public class DiscoSpotfy
        {
            public Albums albums { get; set; }
        }

    }
}
