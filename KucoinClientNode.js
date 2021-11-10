var ccxt = require('ccxt');

//console.log (ccxt.exchanges) // print all available exchanges

let kucoin = new ccxt.kucoin()
kucoin.apiKey = "";
kucoin.secret = "";
kucoin.password = "";

(async function () {
    let balance = await kucoin.fetchBalance()
}) ();

/*
(async () => {
    let kucoin = new ccxt.kucoin()
    let pairs = await kucoin.fetchMarkets ()
    for (let i in pairs){
        console.log (pairs[i].symbol, pairs[i].precision)
    }
}) ();

(async function () {
    let kraken    = new ccxt.kraken ()
    console.log (kraken.id,    await kraken.loadMarkets ())
}) ();
*/

