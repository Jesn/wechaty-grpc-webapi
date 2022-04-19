using Grpc.Core;
using Grpc.Net.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wechaty.Grpc.Application.DTO;
using static Wechaty.Puppet;

namespace Wechaty.Grpc.Application
{
    public class WechatyPuppetService : IWechatyPuppetService
    {
        internal PuppetClient _client;
        internal List<PuppetClientCollection> puppetClientOptions { get; set; } = new List<PuppetClientCollection>();

        private readonly IWechatyPuppetService _service;


        public WechatyPuppetService()
        {
            initClient();
        }


        internal void initClient()
        {

            var request = new StartRequest()
            {
                Token = "insecure_4ad64522-e86d-4a18-afc9-986a9e2078ef",
                GateWayUrl = "https://117.68.176.236:9001"
            };

            if (puppetClientOptions.Count >= 0 && puppetClientOptions.Any(x => x.Token.Equals(request.Token)))
            {
                _client = puppetClientOptions.FirstOrDefault(x => x.Token.Equals(request.Token)).WechatyGateWayPuppetClient;
            }
            if (request.GateWayUrl.ToUpper().StartsWith("HTTP://"))
            {
                var channel = GrpcChannel.ForAddress(request.GateWayUrl);
                _client = new PuppetClient(channel);

                var model = new PuppetClientCollection()
                {
                    GateWayUrl = request.GateWayUrl,
                    Token = request.Token,
                    WechatyGateWayPuppetClient = _client
                };
                puppetClientOptions.Add(model);
            }
            else if (request.GateWayUrl.ToUpper().StartsWith("HTTPS://"))
            {
                var credentials = CallCredentials.FromInterceptor((context, metadata) =>
                {
                    if (!string.IsNullOrEmpty(request.Token))
                    {
                        metadata.Add("Authorization", $"Wechaty {request.Token}");
                    }
                    return Task.CompletedTask;
                });
                var channelCredentials = ChannelCredentials.Create(new SslCredentials(), credentials);

                var channel = GrpcChannel.ForAddress(request.GateWayUrl, new GrpcChannelOptions
                {
                    //HttpClient = httpClient,
                    Credentials = channelCredentials,
                    HttpHandler = new HttpClientHandler
                    {
                        ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
                    },
                });
                _client = new PuppetClient(channel);


                var model = new PuppetClientCollection()
                {
                    GateWayUrl = request.GateWayUrl,
                    Token = request.Token,
                    WechatyGateWayPuppetClient = _client
                };
                puppetClientOptions.Add(model);
            }
        }

        public void StartAsync(StartRequest request)
        {
            //if (puppetClientOptions.Count >= 0 && puppetClientOptions.Any(x => x.Token.Equals(request.Token)))
            //{
            //    _client = puppetClientOptions.FirstOrDefault(x => x.Token.Equals(request.Token)).WechatyGateWayPuppetClient;
            //}
            //if (request.GateWayUrl.ToUpper().StartsWith("HTTP://"))
            //{
            //    var channel = GrpcChannel.ForAddress(request.GateWayUrl);
            //    _client = new PuppetClient(channel);

            //    var model = new PuppetClientCollection()
            //    {
            //        GateWayUrl = request.GateWayUrl,
            //        Token = request.Token,
            //        WechatyGateWayPuppetClient = _client
            //    };
            //    puppetClientOptions.Add(model);
            //}
            //else if (request.GateWayUrl.ToUpper().StartsWith("HTTPS://"))
            //{
            //    var credentials = CallCredentials.FromInterceptor((context, metadata) =>
            //    {
            //        if (!string.IsNullOrEmpty(request.Token))
            //        {
            //            metadata.Add("Authorization", $"Wechaty {request.Token}");
            //        }
            //        return Task.CompletedTask;
            //    });
            //    var channelCredentials = ChannelCredentials.Create(new SslCredentials(), credentials);

            //    var channel = GrpcChannel.ForAddress(request.GateWayUrl, new GrpcChannelOptions
            //    {
            //        //HttpClient = httpClient,
            //        Credentials = channelCredentials,
            //        HttpHandler = new HttpClientHandler
            //        {
            //            ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            //        },
            //    });
            //    _client = new PuppetClient(channel);


            //    var model = new PuppetClientCollection()
            //    {
            //        GateWayUrl = request.GateWayUrl,
            //        Token = request.Token,
            //        WechatyGateWayPuppetClient = _client
            //    };
            //    puppetClientOptions.Add(model);
            //}
            if (_client != null)
            {
                _client.StartAsync(new github.wechaty.grpc.puppet.StartRequest());
                // TODO  add event stream
            }
        }


    }
}
