using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Threading.Tasks;
using HtmlAgilityPack;

public partial class Default : Page
{
    JObject polo_obj = new JObject();
    JObject btrx_obj = new JObject();
    JObject bx_BTC_obj = new JObject();
    JObject bx_ETH_obj = new JObject();
    JObject WTM_obj = new JObject();

    double polo_fee = 0.25 / 100;
    double btrx_fee = 0.25 / 100;
    double bx_fee = 0.25 / 100;

    protected void Page_Load(object sender, EventArgs e)
    {
        Cal_Profit();
    }
    
    public void Button1_Click(object sender, EventArgs e)
    {
        Cal_Profit();
    }

    protected async Task Cal_Profit()
    {
        string[] intCurrencies = { "BTC", "ETH" };

        await LoadDataAsync();

        List<CurrObject> CurrencyList = Get_Curreny_list(intCurrencies);

        get_fx(ref CurrencyList, intCurrencies, polo_obj, btrx_obj, bx_BTC_obj, bx_ETH_obj);

        get_mining_info(ref CurrencyList, WTM_obj);

        post_result(CurrencyList);

    }

    //Dictionary to map Coin name with whattomine ID
    public Dictionary<string, string> WTM_ID_Dict()
    {
        return new Dictionary<string, string>
             {
                { "365", "74" },
                { "adn", "65" },
                { "adz", "157" },
                { "amber", "133" },
                { "ams", "145" },
                { "arg-scrypt", "158" },
                { "arg-sha-256", "170" },
                { "ari", "110" },
                { "aur", "40" },
                { "bcn", "103" },
                { "bela", "182" },
                { "bip", "171" },
                { "bob", "131" },
                { "bsty", "138" },
                { "bta", "144" },
                { "btc", "1" },
                { "btm", "111" },
                { "burn", "90" },
                { "cach", "97" },
                { "cap", "120" },
                { "cbx", "126" },
                { "child", "116" },
                { "ckc", "123" },
                { "cloak", "88" },
                { "crw", "165" },
                { "crypt", "86" },
                { "cto", "134" },
                { "cure", "76" },
                { "cyc", "99" },
                { "dash", "34" },
                { "dcr", "152" },
                { "dem", "180" },
                { "dgb-myriad-groestl", "112" },
                { "dgb-sha-256", "113" },
                { "dgb-skein", "114" },
                { "dgb-qubit", "115" },
                { "dgb-scrypt", "28" },
                { "dgc-sha-256", "124" },
                { "dgc-x11", "125" },
                { "dgc-scrypt", "27" },
                { "dmd", "43" },
                { "dnet", "153" },
                { "doge", "6" },
                { "dope", "61" },
                { "dp", "183" },
                { "dsh", "129" },
                { "duo-scrypt", "140" },
                { "duo-sha-256", "141" },
                { "eac", "19" },
                { "emc2", "15" },
                { "enc", "79" },
                { "epc", "136" },
                { "etc", "162" },
                { "eth", "151" },
                { "exe", "20" },
                { "exp", "154" },
                { "fcn", "102" },
                { "flt", "36" },
                { "frsh", "118" },
                { "fst", "63" },
                { "ftc", "8" },
                { "game", "147" },
                { "gb", "160" },
                { "gdn", "50" },
                { "geo", "135" },
                { "give", "51" },
                { "glc", "81" },
                { "goal", "87" },
                { "grs", "48" },
                { "hal", "122" },
                { "hiro", "33" },
                { "hush", "168" },
                { "hvc", "35" },
                { "iec", "142" },
                { "infx", "149" },
                { "jpc", "80" },
                { "karm", "38" },
                { "kmd", "174" },
                { "kr", "163" },
                { "krb", "176" },
                { "lbc", "164" },
                { "lgc", "57" },
                { "lgd", "68" },
                { "limx", "46" },
                { "ltc", "4" },
                { "ltcx", "78" },
                { "maru", "84" },
                { "max", "73" },
                { "mec", "26" },
                { "meow", "16" },
                { "meth", "75" },
                { "mil", "91" },
                { "mnd", "155" },
                { "mona", "148" },
                { "moon", "119" },
                { "mrc", "41" },
                { "mue", "143" },
                { "mun", "47" },
                { "music", "178" },
                { "myr-scrypt", "32" },
                { "myr-myriad-groestl", "49" },
                { "myr-sha-256", "56" },
                { "myr-yescrypt", "66" },
                { "myr-skein", "67" },
                { "mzc", "70" },
                { "naut", "82" },
                { "nlg", "64" },
                { "nmc", "55" },
                { "nobl", "44" },
                { "note", "146" },
                { "nvc", "30" },
                { "nyan", "17" },
                { "orb", "72" },
                { "pasc", "172" },
                { "pasl", "177" },
                { "pot", "18" },
                { "ppc", "52" },
                { "pxc", "71" },
                { "qbc", "45" },
                { "qcn", "105" },
                { "qrk", "137" },
                { "rby", "95" },
                { "rdd", "11" },
                { "ripo", "108" },
                { "rpc", "58" },
                { "rzr", "96" },
                { "sat2", "39" },
                { "sc", "161" },
                { "score", "181" },
                { "shift", "156" },
                { "sib", "169" },
                { "slg", "117" },
                { "smc", "159" },
                { "spa", "12" },
                { "spc", "77" },
                { "src", "139" },
                { "start", "132" },
                { "tac", "94" },
                { "tips", "2" },
                { "ubq", "173" },
                { "unb", "83" },
                { "uno", "54" },
                { "upm", "106" },
                { "uro", "100" },
                { "usde", "31" },
                { "utc", "3" },
                { "veil", "98" },
                { "via", "107" },
                { "vmc", "62" },
                { "vtc", "5" },
                { "wdc", "29" },
                { "xc", "69" },
                { "xcn", "184" },
                { "xdn", "104" },
                { "xhc", "109" },
                { "xlr", "179" },
                { "xmr", "101" },
                { "xpy", "121" },
                { "xvc", "130" },
                { "xvg", "150" },
                { "xzc", "175" },
                { "yac", "42" },
                { "zcl", "167" },
                { "zec", "166" },
                { "zen", "185" },
                { "zet", "53" },
                { "sigt", "191"}
            };
    }

    public List<CurrObject> Get_Curreny_list(string[] intCurrencies)
    {
        //Get all url
        //HtmlWeb hw = new HtmlWeb();
        //HtmlDocument doc = hw.Load("https://whattomine.com/calculators");


        //Create Currency list to keep chosen currency
        List<CurrObject> CurrList = new List<CurrObject>();

        //Go through all control to check which currrency is chosen
        foreach (Control ctrl in form1.Controls)
        {
            if (ctrl.GetType() == typeof(CheckBox))
            {
                var checkBoxCtrl = (CheckBox)ctrl;
                if (checkBoxCtrl.Checked)
                {
                    foreach (string intCurrency in intCurrencies)
                    {
                        // Get ID
                        string num = checkBoxCtrl.ID.Substring(3);

                        //Create new currency object
                        CurrObject Currency = new CurrObject();

                        Currency.ID = num;

                        var name = (TextBox)form1.FindControl("Cur_" + num);
                        Currency.name = name.Text;

                        var HR80 = (TextBox)form1.FindControl("HR" + num + "_80");
                        Currency.myHR_80 = Convert.ToDouble(HR80.Text);

                        var HR60 = (TextBox)form1.FindControl("HR" + num + "_60");
                        Currency.myHR_60 = Convert.ToDouble(HR60.Text);

                        var HashUnit = (DropDownList)form1.FindControl("HashUnit" + num);
                        Currency.factor = Convert.ToDouble(HashUnit.SelectedItem.Value);

                        Currency.intCurrency = intCurrency;

                        CurrList.Add(Currency);

                    }
                }
            }
        }

        return (CurrList);
    }
    
    public void get_fx(ref List<CurrObject> CurrencyList, string[] intCurrencies, JObject polo_obj, JObject btrx_obj, JObject bx_BTC_obj, JObject bx_ETH_obj)
    {
        
        foreach (CurrObject Currency in CurrencyList)
        {
            string Coin_name = Currency.name;
            string intCurrency = Currency.intCurrency;

            switch (intCurrency)
            {
                case "BTC":
                    Currency.FX_THB = (double)bx_BTC_obj["bids"][0][0];
                    break;
                case "ETH":
                    Currency.FX_THB = (double)bx_ETH_obj["bids"][0][0];
                    break;
                default:
                    Currency.FX_THB = 0;
                    break;
            }
                
            string Name_polo = intCurrency + "_" + Coin_name;
            string Name_btrx = intCurrency + "-" + Coin_name;
                
            try
            {
                Currency.FX_Coin = (double)polo_obj[Name_polo]["bids"][0][0];
                Currency.FX_Coin_fee = polo_fee;
                Currency.FX_THB_fee = bx_fee;
            }
            catch
            {
                try
                {
                    JToken Cur_Token = btrx_obj.SelectToken("$.result[?(@.MarketName == '" + Name_btrx + "')]");

                    Currency.FX_Coin = (double)Cur_Token["Bid"];

                    Currency.FX_Coin_fee = btrx_fee;
                    Currency.FX_THB_fee = bx_fee;
                }
                catch
                {
                    Currency.FX_Coin = 0;
                    Currency.FX_Coin_fee = 0;
                    Currency.FX_THB_fee = 0;
                }
            }
        }
    }
    
    public void get_mining_info(ref List<CurrObject> CurrencyList, JObject WTM_obj)
    {
        Dictionary<string, string> WTM_Num_Table = WTM_ID_Dict();
        
        foreach (CurrObject Currency in CurrencyList)
        {
            string Coin_name = Currency.name;
            
            //Try get data from WTM front page first
            try
            {
                //Get whattomine ID
                string WTM_Num = WTM_Num_Table[Coin_name.ToLower()];

                JToken Cur_Token = WTM_obj["coins"].SelectToken("[?(@..id == " + WTM_Num + ")]");

                //Get Whattomine Data
                Currency.NHR = (double)Cur_Token.First["nethash"];
                Currency.BlockTime = (double)Cur_Token.First["block_time"];
                Currency.BlockReward = (double)Cur_Token.First["block_reward"];
                if (Currency.FX_Coin == 0 & Currency.intCurrency == "BTC")
                {
                    Currency.FX_Coin = (double)Cur_Token.First["exchange_rate"];
                }

            }
            catch
            {
                //if cannot find data in the WTM fron page, try to go into conin id
                try
                {   
                    //Get whattomine ID
                    string WTM_Num = WTM_Num_Table[Coin_name.ToLower()];

                    var wtm_coin = JObject.Parse(new WebClient().DownloadString("https://whattomine.com/coins/" + WTM_Num + ".json"));

                    Currency.NHR = (double)wtm_coin["nethash"];
                    Currency.BlockTime = (double)wtm_coin["block_time"];
                    Currency.BlockReward = (double)wtm_coin["block_reward"];
                    if (Currency.FX_Coin == 0 & Currency.intCurrency == "BTC")
                    {
                        Currency.FX_Coin = (double)wtm_coin["exchange_rate"];
                    }
                }
                catch
                // If cannot find in WTM, then use case by case
                {
                    switch (Coin_name)
                    {
                        case "SPR":
                            var NHR = new WebClient().DownloadString("http://chainz.cryptoid.info/spr/api.dws?q=nethashps");
                            Currency.NHR = Convert.ToDouble(NHR);
                            Currency.BlockTime = 60;
                            Currency.BlockReward = get_SPR_BlkReward();
                            break;
                        default:
                            //Get Whattomine Data
                            Currency.NHR = 1;
                            Currency.BlockTime = 1;
                            Currency.BlockReward = 1;
                            break;
                    }
                }
            }
            Currency.get_return();
        }
    }

    public void post_result(List<CurrObject> CurrencyList)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("Currency", typeof(string));
        dt.Columns.Add("Intermediate", typeof(string));
        dt.Columns.Add("1080Ti", typeof(string));
        dt.Columns.Add("1060", typeof(string));
        dt.Columns.Add("NHR (Same Unit as my_HR)", typeof(string));
        dt.Columns.Add("HR Ratio 1080Ti (%)", typeof(string));
        dt.Columns.Add("HR Ratio 1060 (%)", typeof(string));
        dt.Columns.Add("FX_to_BTC/ETH", typeof(string));
        dt.Columns.Add("FX_to_THB", typeof(string));

        foreach (CurrObject Currency in CurrencyList)
        {
            if (Currency.THB_rev_80 != 0)
            {
                dt.Rows.Add(Currency.name, 
                    Currency.intCurrency,
                    String.Format("{0,12:#0.00}", Currency.THB_rev_80),
                    String.Format("{0,12:#0.00}", Currency.THB_rev_60),
                    String.Format("{0,12:#0,000.00}", Currency.NHR/Currency.factor),
                    String.Format("{0,12:#0.000000}", Currency.myHR_80 * Currency.factor * 100/ Currency.NHR),
                    String.Format("{0,12:#0.000000}", Currency.myHR_60 * Currency.factor * 100/ Currency.NHR),
                    String.Format("{0,12:#0.000000}", Currency.FX_Coin),
                    String.Format("{0,12:#0}", Currency.FX_THB));
            }
        }

        dt.DefaultView.Sort = "1080Ti DESC";
        GridView1.DataSource = dt;
        
        GridView1.DataBind();
        
    }

    public double get_SPR_BlkReward()
    {
        DateTime firstDate = new DateTime(2014, 7, 29, 9, 0, 0);
        DateTime firstHalfDate = new DateTime(2018, 7, 29, 9, 0, 0);

        double nHalf_nom = (DateTime.Now.ToUniversalTime() - firstDate).TotalSeconds; // Need to adjust current time to universal time
        double nHalf_denom = (firstHalfDate - firstDate).TotalSeconds;

        double nHalf = Math.Floor(nHalf_nom / nHalf_denom);

        DateTime recentHalfDate = new DateTime(2014 + 4 * (int)nHalf, 7, 29, 9, 0, 0);
        DateTime nextHalfDate = new DateTime(2014 + 4 * (int)(nHalf+1), 7, 29, 9, 0, 0);
        
        double recentReward = (6.66 / Math.Pow(2,nHalf));
        double nextReward = (6.66 / Math.Pow(2, nHalf + 1));

        double proportion = (DateTime.Now.ToUniversalTime() - recentHalfDate).TotalSeconds / (nextHalfDate - recentHalfDate).TotalSeconds;

        double BlockReward = (nextReward - recentReward) * proportion + recentReward;

        return (BlockReward);
    }

    //Async function
    public async Task LoadDataAsync()
    {
        var polo_task   = get_data("https://poloniex.com/public?command=returnOrderBook&currencyPair=all&depth=1");
        var btrx_task   = get_data("https://bittrex.com/api/v1.1/public/getmarketsummaries");
        var bx_BTC_task = get_data("https://bx.in.th/api/orderbook/?pairing=1");
        var bx_ETH_task = get_data("https://bx.in.th/api/orderbook/?pairing=21");
        var WTM_task    = get_data("http://whattomine.com/coins.json");

        string polo_json    = await polo_task;
        string btrx_json    = await btrx_task;
        string bx_BTC_json  = await bx_BTC_task;
        string bx_ETH_json  = await bx_ETH_task;
        string WTM_json     = await WTM_task;

        polo_obj    = JObject.Parse(polo_json);
        btrx_obj    = JObject.Parse(btrx_json);
        bx_BTC_obj  = JObject.Parse(bx_BTC_json);
        bx_ETH_obj  = JObject.Parse(bx_ETH_json);
        WTM_obj     = JObject.Parse(WTM_json);

    }

    public async Task<string> get_data(string url)
    {
        WebClient WebClient = new WebClient();
        return await WebClient.DownloadStringTaskAsync(url);
        
    }

    //Class
    public class CurrObject
    {
        public string ID { get; set; }
        public string name { get; set; }

        public string intCurrency { get; set; }

        //From poloniex or bittrex
        public double FX_Coin { get; set; }
        public double FX_THB { get; set; }

        public double FX_Coin_fee { get; set; }
        public double FX_THB_fee { get; set; }

        // From WTM or their website
        public double NHR { get; set; }
        public double BlockTime { get; set; }
        public double BlockReward { get; set; }

        // From website
        public double myHR_80 { get; set; }
        public double myHR_60 { get; set; }
        public double factor { get; set; }

        public double btc_rev_80;
        public double btc_rev_60;

        public double THB_rev_80;
        public double THB_rev_60;


        public void get_return()
        {
            btc_rev_80 = myHR_80 / NHR * (86400 / BlockTime) * BlockReward * factor * FX_Coin * (1 - FX_Coin_fee);
            btc_rev_60 = myHR_60 / NHR * (86400 / BlockTime) * BlockReward * factor * FX_Coin * (1 - FX_Coin_fee);
            
            THB_rev_80 = btc_rev_80 * FX_THB * (1 - FX_THB_fee);
            THB_rev_60 = btc_rev_60 * FX_THB * (1 - FX_THB_fee);
        }

    }


    ////unused, keep for reference
    //public Dictionary<string, double> get_fx_table_bx()
    //{

    //    string[] main_currency = { "BTC", "ETH" };
    //    double Currency = 0;

    //    Dictionary<string, double> FX_Table = new Dictionary<string, double> { };

    //    // get BTC to THB Data
    //    var bx_BTC_json = new WebClient().DownloadString("https://bx.in.th/api/orderbook/?pairing=1");
    //    var bx_BTC_obj = JObject.Parse(bx_BTC_json);

    //    Currency = (double)bx_BTC_obj["bids"][0][0];
    //    FX_Table.Add("THB_BTC", Currency);

    //    // get ETH to THB Data
    //    var bx_ETH_json = new WebClient().DownloadString("https://bx.in.th/api/orderbook/?pairing=21");
    //    var bx_ETH_obj = JObject.Parse(bx_ETH_json);

    //    Currency = (double)bx_ETH_obj["bids"][0][0];
    //    FX_Table.Add("THB_ETH", Currency);

    //    return (FX_Table);

    //}

}