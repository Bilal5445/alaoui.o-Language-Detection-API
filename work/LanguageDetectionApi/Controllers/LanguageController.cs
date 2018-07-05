using DialogueMaster.Babel;
using DialogueMaster.Classification;
using LanguageDetectionApi.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WinSample;

namespace LanguageDetectionApi.Controllers
{
    [RoutePrefix("api/Language")]
    public class LanguageController : ApiController
    {

        IBabelModel m_Model;
        BabelModel okjk = new BabelModel();
        public string x1 = "AA,aando,ach,achmn,achne,achno,Akhti,Akhtii,ana,andhom,asg,awdi,awdii,axmn,ay,ayi,b,bach,Bacha,Bachahal,Bachahl,Bagha,baghi,baki,bali,ban,bante,barit,basah,bax,bazaf,bch,bchhal,bchi,bchitaman,beghit,Beghite,Bgha,bghayt,Bghina,bghit,bghite,bghitha,Bghitt,Bghut,Bghyt,bgit,bgito,bihoum,bik,bin,binatkom,binatna,binek,bini,bit,Bixahla,biya,bjoj,bjouj,bla,brayt,brit,brite,bsah,btaman,bzaaf,bzaf,bzf,bzzf,ch,chi,chkon,chkoun,chmen,chmn,chno,hhnou,chof,lia,chorout,chrihaaa,ctro,daba,dak,dar,dar,darou,dayr,dayra,dayrin,db,dert,dial,dik,dima,din,dir,dirou,diyal,drb,dyal,dyalha,dyalhoum,dyalo,dyl,ee,ela,endi,f,fach,fal,fash,fax,fe,fel,fi,fia,fiha,fihom,fihoum,fik,fiki,fikoum,fina,fine,fiya,frzo,fx,fya,gh,Ghadi,ghda,ghi,ghir,go,l,h,had,hada,hadak,hadchi,hade,hadi,hado,hadou,hadxi,haja,hana,hanti,hat,hata,hatchi,heta,hia,hir,hit,hiya,hna,ho,hoa,houa,hta,hwa,hya,ido,ikon,il,ila,imta,ina,incha,inxa,iwa,iyah,ja,jawbo,jawboni,jawbt,jit,jwbo,kain,kam,kan,kanb4i,kanbda,kanbghi,kanhtajha,Kanmout,kant,kayen,kayena,kayenin,kayn,kayna,khas,khasni,khass,khdit,Khodi,khoti,khouti,khouya,khoya,khsni,khti,kif,kifach,kifax,kima,kin,kindir,kohom,kolchi,kolna,kolo,kolona,kon,kont,konx,koulna,kount,kter,l,lah,lah,lakom,leya,lgharad,lhal,li,lia,lih,liha,lihoum,lik,likom,lina,liya,lkhot,lok,lya,Lyom,Lyoma,m,M3ach,M3ax,machi,makaynch,malk,man,mane,mara,matfoutch,matx,maxi,mazal,mazyan,mcha,mchat,Mchhal,mchi,mchit,mchiw,memkin,men,men rda, mera, Mezyana, mhtj, mi, mjoud, mli, mlk, mlyon, mmkin, mn, momki, momkin, momkin l,monasib,monassib,n,na,naaraf,nacherii,naftah,nakhod,namchi,namchiw n, nari, narii, Nbaliw, nbdlha, Nchri, nchriha, ndir, ndiroha, nhar, nkhdem, nkhoud, nkono, nkri, nsawlak, nshofo, nshriha, nstafd, nta, ntia, Ntmana, Ntmnaw, ntolo, ntoma, ntouma, ntsnaw, ntya, nxri, o, o3andi, o3endi, obghit, obrit, ochi, ochno, ofih, Ofin, ola, omhtaja, ouach, plize, Q, ra, rah, raha, rahna, rahoum, rani, rer, rir, rizo, salam, salame, salamo, salm, sbah, sbh, shi, shnou, shnu, sift, sifto, sir, siri, siro, sirou, slam, Slm, tafasil, tajwboni, taman, tdir, techri, tfawed, tfo, tjrabha, tkon, tkoun, tmchi, toma, touma, Twkeel, twkl, twkli, w, wa, waa, waaa, waahda, wach, wache, wahda, wahed, wal, walou, wana, wash, wax, wch, wehda, wel, wela, welad, whta, wla, wlad, Wlahila, wld, Wlit, Wlit,, Wlito, Wlitoo, wno, wnou, wntoma, wordsletters, wslat, wslt, xhal, xi, xini, xiwhda, xkon, xkoon, xno, xnu, xofo, xokran, xokrn, xrit, xukran, ya, yak, yaka, yakou, yalah, yallah, yamken, yamkn, yarab, yarabi, yla, ymken, ymkn, ymta, yslah, zwin, zwina,";

        LanguageController()
        {
            this.m_Model = BabelModel._AllModel;
            int i = 0;
            foreach (String lang in m_Model.Keys)
            {
                object val = lang;
                try
                {
                
                    val = GetLanguageCulture(lang);
                    //okjk.Add(lang, val);
                    
                    
                    //okjk.Values.Add(m_Model.Values[i]);
                    //var lkjlk = val.GetType();
                    //ITokenTable catTable;
                    //ITokenStats dd = new ITokenStats();

                    //foreach (var tyut in m_Model)
                        //i++;


                }
                catch { };

                int k = 0;
                foreach(var fgrt in m_Model.Values)
                {
                    if(i == k)
                    {
                        okjk.Add(lang, fgrt);
                    }
                    k++;
                }

                //var dfkjvfd = m_Model.Values[i];

                //okjk.Add(lang, m_Model.Values[i]);

                i++;
            }
        }


        private readonly Dictionary<string, ITokenTable> m_InnerDictionary = new Dictionary<string, ITokenTable>();

        public ICollection<string> Keys
        {
            get { return this.m_InnerDictionary.Keys; }
        }

        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("Detect")]
        [HttpGet]
        public HttpResponseMessage GetDiscussionBords(string Mytext)
        {
            HttpResponseMessage message = null;
            try
            {
                string tea = Mytext;
                string baad = "";
                bool nothavenum = true;
                bool notarabizi = false;
                if (tea.Contains("2") || tea.Contains("3") || tea.Contains("4") || tea.Contains("5") || tea.Contains("7") || tea.Contains("9"))
                {
                    baad = showresponce("arz");
                    //return;
                    nothavenum = false;
                }
                else if (nothavenum)
                {
                    string[] string1 = x1.Split(',');
                    string[] string2 = tea.Split(' ');
                    string[] m = string1.Distinct().ToArray();
                    string[] n = string2.Distinct().ToArray();
                    string Test;
                    var results = m.Intersect(n, StringComparer.OrdinalIgnoreCase);
                    Test = String.Join(" ", results);
                    //return Test;
                    var aad = Test;
                    if(aad != null && aad != "")
                    {
                        baad = showresponce("arz");
                    }
                    else
                    {
                        notarabizi = true;
                    }


                }

                if (notarabizi)
                {
                    DemoForm kjsdfn = new DemoForm();
                    //var kdjffd = kjsdfn.


                    //this.cbLangCompare.SelectedIndex = -1;
                    //var ty = okjk.ClassifyTextSimple(tea);

                    DialogueMaster.Classification.ICategoryList result = okjk.ClassifyText(tea);
                    //this.tbResult.Text = result.ToString();
                    if (result.Count > 0)
                    {
                        var infoooo = GetLanguageCulture(result[0].Name);
                        //this.cbLangCompare.SelectedItem = GetLanguageCulture(result[0].Name);

                        baad = showresponce(infoooo.Name);
                    }


                
                    
                }


                if (baad != null && baad != "")
                {

                }
                else
                {
                    baad = "Error Occured";//la langue détectée est

                }



                

                message = this.Request.CreateResponse(HttpStatusCode.OK, baad);
            }
            catch (Exception ex)
            {
                message = this.Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }

            return message;
        }




        #region supporting method

        public string showresponce(string value)
        {
            if (value == "arz" || value == "ar" || value == "fr" || value == "en" || value == "es")
            {
                return value;
            }
            else
            {
                return"Other";//la langue détectée est
            }
        }

        public static CultureInfo GetLanguageCulture(string lang)
        {
            object val = lang;
            try
            {
                return CultureInfo.GetCultureInfoByIetfLanguageTag(lang);
            }
            catch
            {
                foreach (CultureInfo ci in CultureInfo.GetCultures(CultureTypes.AllCultures))
                {
                    if (ci.TwoLetterISOLanguageName == lang)
                    {
                        return ci;
                    }
                }
            }
            throw new ArgumentException("lang", "Unknwon language");
        }

//        public ICategoryList ClassifyText(string text)
//        {
//            return ClassifyText(text, 2);
//        }

//        public ICategoryList ClassifyText(string text, int maxResults)
//        {
//            long startTime = DateTime.Now.Ticks;
//            ListDictionary results = new ListDictionary();
//            Dictionary<string, double> scores = new Dictionary<string, double>();
//            TokenTable tblTest = new TokenTable(text);
//            double maxScore = 0;
//            double threshold = 0;


//            List<TokenVoter> charsetVoters = new List<TokenVoter>();
//            // collect stats based on charset (first filter)
//            foreach (string category in this.Keys)
//            {
//                ITokenTable catTable = this[category];
//                if (!catTable.Enabled)
//                    continue;
//                double score = catTable.CharsetTable.CharsetComparisonScore(tblTest.CharsetTable, threshold);

//                if (score > maxScore)
//                {
//                    maxScore = score;
//                    threshold = (maxScore * this.m_Threshold);
//                }
//                if (score > threshold)
//                    charsetVoters.Add(new TokenVoter(category, score));
//            }

//            // chinese does not have a "Charset"... so to be sure....
//            if ((charsetVoters.Count < 3) && (this.Keys.Contains("zh")))
//                charsetVoters.Add(new TokenVoter("zh"));

//            charsetVoters.Sort();
//            for (int i = charsetVoters.Count - 1; i > -1; i--)
//            {
//                if (charsetVoters[i].Score < threshold)
//                    charsetVoters.RemoveAt(i);
//            }


//            maxScore = 0; ;
//            // collect scores for each table
//            int maxWordHits = 0;
//            threshold = 0;
//            foreach (TokenVoter charVoter in charsetVoters)
//            {
//                ITokenTable catTable = this[charVoter.Category];
//                if (!catTable.Enabled)
//                    continue;
//                int hits = 0;
//                double score = catTable.WordComparisonScore(tblTest, threshold, ref hits);
//                if (hits > maxWordHits)
//                    maxWordHits = hits;

//                if (score > maxScore)
//                {
//                    maxScore = score;
//                    threshold = (maxScore * this.m_Threshold);
//                }
//                if (score > threshold)
//                    scores.Add(charVoter.Category, score);
//            }

//            double sumScore = 0;
//            List<TokenVoter> voters = new List<TokenVoter>();
//            if (scores.Count == 0)
//            {
//                maxScore = charsetVoters[0].Score; ;
//                // take the voters from the closed charsert
//                foreach (TokenVoter v in charsetVoters)
//                {

//                    scores.Add(v.Category, v.Score);
//                }

//            }
//            threshold = (maxScore * m_Threshold);


//            // copy the scores to a sorted voters list
//            foreach (string key in scores.Keys)
//            {
//                /*	if ((long)scores[key] < threshold)
//                        continue; 
//                        */
//                // calc sum score
//                double score = scores[key];
//                /*
//                if (maxWordHits < 1)
//                {
//                    score = 0; //  score > 0 ? 1 : 0;
//                }
//                else*/
//                if (score > threshold)
//                {
//                    score /= maxScore;
//                    if (maxWordHits > 0)
//                        score /= maxWordHits;
//                    score *= 100;
//                    sumScore += score;
//                    voters.Add(new TokenVoter(key, score));
//                }


//            }


//            if (voters.Count > 1)
//            {
//                if (sumScore > 0)
//                {
//                    voters.Sort();
//                    // cleanup voters and rebalance if more than 3 voters...
//                    if (voters.Count > m_MaxVoters)
//                    {
//                        sumScore = 0;
//                        for (int i = 0; i < m_MaxVoters; i++)
//                        {
//                            ((TokenVoter)voters[i]).Score -= ((TokenVoter)voters[m_MaxVoters]).Score;
//                            sumScore += ((TokenVoter)voters[i]).Score;
//                        }
//                        voters.RemoveRange(m_MaxVoters, voters.Count - m_MaxVoters);
//                    }
//                }
//            }

//            // now normalize results..
//            // the results are not an absolute confidence
//            // but relative 
//            if (voters.Count == 1)
//            {
//                // only one voter, so it we are 100% sure that's the one!
//                ScoreHolder newScore = new ScoreHolder(100);
//                results.Add(((TokenVoter)voters[0]).Category, newScore);
//            }
//            else
//            {
//                for (int i = 0; i < voters.Count; i++)
//                {
//                    TokenVoter stats = voters[i] as TokenVoter;

//                    double percScore = sumScore > 0 ? (stats.Score / sumScore) * 100 : 0;
//                    results.Add(stats.Category, new ScoreHolder(percScore));
//                }


//                // if we have more than one possible result
//                // we will try to disambiguate it by checking for 
//                // very common words 
//                if ((results.Count == 0) || (results.Count > 1))
//                {
//                    scores.Clear();
//                    maxScore = 0;
//                    threshold = 0;
//                    // collect scores for each table
//                    foreach (string category in results.Keys)
//                    {
//                        ITokenTable catTable = (ITokenTable)this[category];
//                        // threshold = tblTest.WordTable. Ranks*catTable.WordTable.Count;
//                        double score = catTable.ComparisonScore(tblTest, threshold);
//                        if (score > 0)
//                        {
//                            maxScore = System.Math.Max(maxScore, score);
//                            scores.Add(category, score);
//                        }
//                    }
//                    // got results?
//                    if (scores.Count > 0)
//                    {

//                        sumScore = 0;
//                        // copy the scores to a sorted voters list
//                        voters.Clear();
//                        foreach (string key in scores.Keys)
//                        {
//                            // calc sum score
//                            sumScore += scores[key];
//                            voters.Add(new TokenVoter(key, scores[key]));
//                        }
//                        voters.Sort();


//                        // now normalize results..
//                        // the results are not an absolute confidence
//                        // but relative 
//                        if (voters.Count == 1)
//                        {
//                            // only one voter, so all other results are only 3/4 value
//                            foreach (string category in results.Keys)
//                                if (category != ((TokenVoter)voters[0]).Category)
//                                    ((ScoreHolder)results[category]).DevideScore(0.75);
//                        }
//                        else
//                        {
//                            for (int i = 0; i < voters.Count; i++)
//                            {
//                                TokenVoter stats = voters[i] as TokenVoter;

//                                double percScore = (stats.Score / sumScore) * 200;
//                                ((ScoreHolder)results[stats.Category]).AddScore(percScore);
//                            }
//                            foreach (string category in results.Keys)
//                                ((ScoreHolder)results[category]).DevideScore(0.75);

//                        }
//                    }

//                }
//            }
//            // now build a proper result..
//            voters.Clear();
//            foreach (string key in results.Keys)
//            {
//                voters.Add(new TokenVoter(key, ((ScoreHolder)results[key]).Score));
//            }
//            voters.Sort();

//            /*
//            // Do a distance to next boos 
//            for (int i = 0; i < voters.Count-1; i++)
//            {
//                voters[i].Score += voters[i].Score - voters[i + 1].Score;
//            }
//            */

//            // reduce to maximum results
//            if (voters.Count > maxResults)
//            {
//                voters.RemoveRange(maxResults, voters.Count - maxResults);
//            }


//            // re-weight...
//            double dSumScore = 0;
//            foreach (TokenVoter voter in voters)
//            {
//                dSumScore += voter.Score;
//            }
//            results.Clear();
//            foreach (TokenVoter voter in voters)
//            {
//                results.Add(voter.Category, new ScoreHolder((voter.Score / dSumScore) * 100));
//            }
//            //			ArrayList resultList = new ArrayList(results.Values);
//            //			resultList.Sort
//            CategoryList result = new CategoryList();
//            foreach (string category in results.Keys)
//                result.Add(new Category(category, ((ScoreHolder)results[category]).Score));
//            result.Sort();
//#if DIALOGUEMASTER
//			if (UseCounters)
//			{
//				m_Counters.Classifications.Increment();
//				m_Counters.ClassificationsPerSecond.Increment();
//				m_Counters.ComparisonTime.IncrementBy(DateTime.Now.Ticks - startTime);
//				m_Counters.ComparisonTimeBase.Increment();
//			}
//#endif
//            tblTest.Clear();
//            return result;
//        }

        #endregion


    }


}
