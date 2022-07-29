﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Alura.LeilaoOnline.Selenium.Helpers
{
    public class SelectMaterialize
    {
        private IWebDriver driver;
        private IWebElement selectWrapper;
        private IEnumerable<IWebElement> opcoes;

        public SelectMaterialize(IWebDriver driver, By locatorSelectWrapper)
        {
            this.driver = driver;
            selectWrapper = driver.FindElement(locatorSelectWrapper);
            opcoes = selectWrapper.FindElements(By.CssSelector("li>span"));

        }

        private void OpenWrapper()
        {
            selectWrapper.Click();
        }
        private void LoseFocus()
        {
            selectWrapper
                    .FindElement(By.TagName("li"))
                    .SendKeys(Keys.Tab);
        }

        public void DeselectAll()
        {
            OpenWrapper();
            opcoes.ToList().ForEach(o =>
            {
                o.Click();
            });
            LoseFocus();
        }

        public void SelectByText(List<string> options)
        {
            OpenWrapper();
            options.ForEach(categ =>
            {
                opcoes
                     .Where(o => o.Text.Contains(categ))
                     .ToList()
                     .ForEach(o =>
                     {
                         o.Click();
                     });
            });
            LoseFocus();
        }


    }
}
