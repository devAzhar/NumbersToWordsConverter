namespace NumbersToWordsConverter.Web.Controllers
{
    using Core.Interfaces;
    using Core.Services;
    using Models;
    using System;
    using System.Web.Mvc;

    public class CurrencyToWordsConverterController : Controller
    {
        private ICurrencyToWordsConverter CurrencyToWordsConverter { get; set; }

        public CurrencyToWordsConverterController(ICurrencyToWordsConverter currencyToWordsConverter)
        {
            this.CurrencyToWordsConverter = currencyToWordsConverter;
        }

        /// <summary>
        /// Converts the specified input model.
        /// </summary>
        /// <param name="inputModel">The input model.</param>
        /// <returns>JSON Result for NumbersToWordsConverter.Web.Models.ServiceResponse</returns>
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public JsonResult Convert(CurrencyToWordsInputModel inputModel)
        {
            var result = new ServiceResponse();

            try
            {
                result.Result = this.CurrencyToWordsConverter.Convert(inputModel.Amount, inputModel.CurrencyName, inputModel.CurrencyCentsName);
            }
            catch(Exception exp)
            {
                result.ErrorMessage = exp.Message;
            }

            return this.Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}