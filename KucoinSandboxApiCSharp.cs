using System;
using Kucoin;
using Kucoin.Net;
using Kucoin.Net.Objects;
using Kucoin.Net.SocketSubClients;
using Kucoin.Net.Interfaces;
using System.Threading.Tasks;
using System.Threading;

namespace KucoinTest
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            KucoinApiAddresses kad = new KucoinApiAddresses();
            kad.SpotAddress = "https://openapi-sandbox.kucoin.com/api";
            var client = new KucoinClient(new KucoinClientOptions(kad)
            {
                // Specify options for the client
                ApiCredentials = new KucoinApiCredentials("", "", "")
            });

            /*var client = new KucoinClient(new KucoinClientOptions()
            {
                // Specify options for the client
            });*/

            Console.WriteLine("Spot base address = " + client.Spot.BaseAddress);

            /*while(true)
            {
                var callResult = await client.Spot.GetTickersAsync();
                // Make sure to check if the call was successful
                if (!callResult.Success)
                {
                    // Call failed, check callResult.Error for more info
                }
                else
                {
                    // Call succeeded, callResult.Data will have the resulting data
                    Console.WriteLine("success");
                    Console.WriteLine(callResult.Data.ToString());
                    foreach (var a in callResult.Data.Data)
                    {
                        Console.WriteLine(a.Symbol);
                    }
                }
            }*/

            //var callResult = await client.Spot.PlaceOrderAsync("XRPUSDT", KucoinOrderSide.Buy, KucoinNewOrderType.Limit, quantity: 10, price: 50, timeInForce: KucoinTimeInForce.GoodTillCancelled);
            var callResult = await client.Spot.PlaceOrderAsync("BTC-USDT", "2", KucoinOrderSide.Buy, KucoinNewOrderType.Market, funds: 100, timeInForce: KucoinTimeInForce.GoodTillCancelled);
            
            // Make sure to check if the call was successful
            if (!callResult.Success)
            {
                // Call failed, check callResult.Error for more info
                Console.WriteLine("Order placed ERR : " + callResult.Error);
            }
            else
            {
                // Call succeeded, callResult.Data will have the resulting data
                Console.WriteLine("Order placed OK, order id : " + callResult.Data.OrderId);
            }



            Console.WriteLine("end");
            Console.ReadLine();
        }
    }
}
