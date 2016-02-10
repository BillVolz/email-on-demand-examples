﻿using System;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using SocketLabs.Inbound.Shared;

namespace SocketLabs.Inbound.Generator
{
    class Client : IDisposable
    {
        private readonly HttpClient _client = new HttpClient();
        private const int ServerId = 1000;
        private const string SecretKey = "BLABLABLA";

        public Client(string baseUri)
        {
            _client.BaseAddress = new Uri(baseUri);
            
        }
        public HttpResponseMessage SendSampleMessage()
        {
            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(sampleMessage)))
            {
                var serializer = new DataContractJsonSerializer(typeof(MessageEnvelope));
                var messaegEnvelope = (MessageEnvelope)serializer.ReadObject(ms);
                return _client.PostAsJsonAsync<MessageEnvelope>("/api/inbound/", messaegEnvelope).Result;
            }
         
        }
        

        public void Dispose()
        {
            _client.Dispose();
        }

        const string sampleMessage = @"{
    ""SecretKey"":""1234"",
    ""Message"":{
        ""TextCharSet"":""us-ascii"",
        ""HtmlCharSet"":""us-ascii"",
        ""EmbeddedMedia"":null,
        ""MailingId"":null,
        ""MessageId"":null,
        ""Subject"":""This is the subject of a test message."",
        ""TextBody"":""This is the body of the test message.\r\n"",
        ""HtmlBody"":""\u003chtml xmlns:v=\""urn:schemas-microsoft-com:vml\"" xmlns:o=\""urn:schemas-microsoft-com:office:office\"" xmlns:w=\""urn:schemas-microsoft-com:office:word\"" xmlns:m=\""http://schemas.microsoft.com/office/2004/12/omml\"" xmlns=\""http://www.w3.org/TR/REC-html40\""\u003e\u003chead\u003e\u003cMETA HTTP-EQUIV=\""Content-Type\"" CONTENT=\""text/html; charset=us-ascii\""\u003e\u003cmeta name=Generator content=\""Microsoft Word 15 (filtered medium)\""\u003e\u003cstyle\u003e\u003c!--\r\n/* Font Definitions */\r\n@font-face\r\n\t{font-family:\""Cambria Math\"";\r\n\tpanose-1:2 4 5 3 5 4 6 3 2 4;}\r\n@font-face\r\n\t{font-family:Calibri;\r\n\tpanose-1:2 15 5 2 2 2 4 3 2 4;}\r\n/* Style Definitions */\r\np.MsoNormal, li.MsoNormal, div.MsoNormal\r\n\t{margin:0in;\r\n\tmargin-bottom:.0001pt;\r\n\tfont-size:11.0pt;\r\n\tfont-family:\""Calibri\"",\""sans-serif\"";}\r\na:link, span.MsoHyperlink\r\n\t{mso-style-priority:99;\r\n\tcolor:#0563C1;\r\n\ttext-decoration:underline;}\r\na:visited, span.MsoHyperlinkFollowed\r\n\t{mso-style-priority:99;\r\n\tcolor:#954F72;\r\n\ttext-decoration:underline;}\r\nspan.EmailStyle17\r\n\t{mso-style-type:personal-compose;\r\n\tfont-family:\""Calibri\"",\""sans-serif\"";\r\n\tcolor:windowtext;}\r\n.MsoChpDefault\r\n\t{mso-style-type:export-only;\r\n\tfont-family:\""Calibri\"",\""sans-serif\"";}\r\n@page WordSection1\r\n\t{size:8.5in 11.0in;\r\n\tmargin:1.0in 1.0in 1.0in 1.0in;}\r\ndiv.WordSection1\r\n\t{page:WordSection1;}\r\n--\u003e\u003c/style\u003e\u003c!--[if gte mso 9]\u003e\u003cxml\u003e\r\n\u003co:shapedefaults v:ext=\""edit\"" spidmax=\""1026\"" /\u003e\r\n\u003c/xml\u003e\u003c![endif]--\u003e\u003c!--[if gte mso 9]\u003e\u003cxml\u003e\r\n\u003co:shapelayout v:ext=\""edit\""\u003e\r\n\u003co:idmap v:ext=\""edit\"" data=\""1\"" /\u003e\r\n\u003c/o:shapelayout\u003e\u003c/xml\u003e\u003c![endif]--\u003e\u003c/head\u003e\u003cbody lang=EN-US link=\""#0563C1\"" vlink=\""#954F72\""\u003e\u003cdiv class=WordSection1\u003e\u003cp class=MsoNormal\u003eThis is the body of the test message.\u003co:p\u003e\u003c/o:p\u003e\u003c/p\u003e\u003c/div\u003e\u003c/body\u003e\u003c/html\u003e"",
        ""CustomHeaders"":[
        {
            ""Name"":""Received"",
            ""Value"":""from smtp176.dfw.emailsrvr.com ([67.192.241.176]) by mx.socketlabs.com with ESMTP; Mon, 20 May 2013 10:01:04 -0400""
        },
        {
            ""Name"":""Received"",
            ""Value"":""from localhost (localhost.localdomain [127.0.0.1])by smtp7.relay.dfw1a.emailsrvr.com (SMTP Server) with ESMTP id F39D3258692for \u003ctest@customerexample.com\u003e; Mon, 20 May 2013 10:00:47 -0400 (EDT)""
        },
        {
            ""Name"":""Received"",
            ""Value"":""from smtp192.mex07a.mlsrvr.com (unknown [67.192.133.128])by smtp7.relay.dfw1a.emailsrvr.com (SMTP Server) with ESMTPS id 3E6022586DEfor \u003ctest@customerexample.com\u003e; Mon, 20 May 2013 10:00:45 -0400 (EDT)""
        },
        {
            ""Name"":""Received"",
            ""Value"":""from DFW1MBX19.mex07a.mlsrvr.com ([192.168.1.230]) byDFW1HUB14.mex07a.mlsrvr.com ([fe80::222:19ff:fe00:52bd%11]) with mapi; Mon,20 May 2013 09:00:45 -0500""
        },
        {
            ""Name"":""X-Virus-Scanned"",
            ""Value"":""OK""
        },
        {
            ""Name"":""Date"",
            ""Value"":""Mon, 20 May 2013 09:00:52 -0500""
        },
        {
            ""Name"":""Thread-Topic"",
            ""Value"":""This is the subject of a test message.""
        },
        {
            ""Name"":""Thread-Index"",
            ""Value"":""Ac5VYnBo0JcanJnQTWSVA0k86Viq/Q==""
        },
        {
            ""Name"":""Message-ID"",
            ""Value"":""\u003cCC49375B755FC1499ECDFBA782412D5F08F64FD3E6@DFW1MBX19.mex07a.mlsrvr.com\u003e""
        },
        {
            ""Name"":""Accept-Language"",
            ""Value"":""en-US""
        },
        {
            ""Name"":""Content-Language"",
            ""Value"":""en-US""
        },
        {
            ""Name"":""X-MS-Has-Attach"",
            ""Value"":null
        },
        {
            ""Name"":""X-MS-TNEF-Correlator"",
            ""Value"":null
        },
        {
            ""Name"":""acceptlanguage"",
            ""Value"":""en-US""
        },
        {
            ""Name"":""Content-Type"",
            ""Value"":""multipart/alternative;boundary=\""_000_CC49375B755FC1499ECDFBA782412D5F08F64FD3E6DFW1MBX19mex0_\""""
        },
        {
            ""Name"":""MIME-Version"",
            ""Value"":""1.0""
        }
        ],
        ""To"":[{
            ""EmailAddress"":""test@customerexample.com"",
            ""FriendlyName"":""Test Recipient""
        }],
        ""Cc"":null,
        ""Bcc"":null,
        ""From"":{
            ""EmailAddress"":""sender@example.com"",
            ""FriendlyName"":""Example Sender""
        },
        ""ReplyTo"":null,
        ""Attachments"":null
    },
    ""InboundMailFrom"":""sender@example.com"",
    ""InboundRcptTo"":""test@customerexample.com"",
    ""InboundIpAddress"":""10.10.10.10"",
    ""ErrorLog"":null,
    ""SpamScore"":0,
    ""SpamDetails"":null
}";
    }
}
