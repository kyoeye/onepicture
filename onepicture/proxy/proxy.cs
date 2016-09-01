using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace onepicture
{
    public class imageproxy
    {
        public async static Task<RootObject> goimage()
        {
            var http = new HttpClient();
            var response = await http.GetAsync("http://lelouchcrgallery.tk/rand");
            var result = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(RootObject));

            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (RootObject)serializer.ReadObject(ms);
            return data;
        }

    }

    [DataContract]
    public class RootObject
    {


        [DataMember]
        public string p_ori { get; set; }
        [DataMember]
        public string p_ori_hight { get; set; }
        [DataMember]
        public string p_ori_width { get; set; }
        [DataMember]
        public string p_mid { get; set; }
        [DataMember]
        public string p_mid_hight { get; set; }
        [DataMember]
        public string p_mid_width { get; set; }
        [DataMember]
        public string p_source { get; set; }
        [DataMember]
        public string ranTotal { get; set; }
    }

  public class homeimageclass
    {
        public async static Task<RootObject1> goimage1()
        {
            var http = new HttpClient();
            var response1 = await http.GetAsync("http://lelouchcrgallery.tk/rand?ratio=1.9&range=0.4&source=pixiv");
            var result1 = await response1.Content.ReadAsStringAsync();
            var serializer1 = new DataContractJsonSerializer(typeof(RootObject1));

            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result1));
            var data = (RootObject1)serializer1.ReadObject(ms);
            return data;
        }

        public class RootObject1
        {


            [DataMember]
             public string p_ori { get; set; }
            [DataMember]
            public string p_ori_hight { get; set; }
            [DataMember]
            public string p_ori_width { get; set; }
            [DataMember]
            public string p_mid { get; set; }
            [DataMember]
            public string p_mid_hight { get; set; }
            [DataMember]
            public string p_mid_width { get; set; }
            [DataMember]
            public string p_source { get; set; }
            [DataMember]
            public string ranTotal { get; set; }
        }
    }
   
}

