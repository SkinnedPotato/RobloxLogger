using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RobloxLogger
{
    class LoginTool
    {
        static void Main(string[] args){
            string username = null;
            string password = null;
            string profileUrl = null;

            ParseXMLFileForLoginDetails(Console.ReadLine());
            





            void ParseXMLFileForLoginDetails(String profile) { //Loads the XML doc. btw a node is just a tag and Also sets user + pass variables
                try {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load("AccountDetails.xml");
                    XmlNodeList xmlNodeList = xmlDoc.GetElementsByTagName(profile);
                    //Sets Login Variables
                    username = xmlNodeList[0].FirstChild.InnerText;
                    password = xmlNodeList[0].FirstChild.NextSibling.InnerText;
                    profileUrl = xmlNodeList[0].LastChild.InnerText;
                }
                catch(Exception e) {
                    Console.WriteLine("Account not found, Enter again");
                }
                LoginToProfile(username, password, profileUrl);
            }

            void LoginToProfile(string username2,string password2, string profileUrl2){ //Variables are named with a 2 after to avoid compiler errors but names still imply the same meaning
                if(username2 != null && password2 != null && profileUrl2 != null) {
                    IWebDriver browser = new ChromeDriver();
                    browser.Navigate().GoToUrl("https://www.roblox.com/NewLogin"); //goes to roblox login and enters all the shit
                    browser.FindElement(By.Name("username")).SendKeys(username2);  
                    browser.FindElement(By.Name("password")).SendKeys(password2);
                    browser.FindElement(By.Id("login-button")).Click();
                }
                else {
                    ParseXMLFileForLoginDetails(Console.ReadLine()); //Goes back to looking for acc details
                }

            }
        }
    }
}
