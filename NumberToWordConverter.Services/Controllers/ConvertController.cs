using NumberToWordConverter.Core.Response;
using NumberToWordConverter.Core.ViewModel;
using NumberToWordConverter.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NumberToWordConverter.Services.Controllers
{
    public class ConvertController : ApiController
    {
        #region Property

        private readonly IConvertRepository _convertRepository;

        #endregion

        /// <summary>
        /// ConvertController Constructor
        /// </summary>
        /// <param name="convertRepository"></param>
        public ConvertController(IConvertRepository convertRepository)
        {
            _convertRepository = convertRepository;
        }

        #region API Methods

        /// <summary>
        /// api/Convert/ConvertWords
        /// </summary>
        /// <param name="model"></param>
        /// <returns>IHttpActionResult</returns>
        [HttpPost]
        public IHttpActionResult ConvertWords([FromBody]ConvertWordsModel model)
        {
            try
            {
                return Ok(new ConvertWordsResult()
                {
                    Success = true,
                    Name = model.Name,
                    CurrencyWords = _convertRepository.ConvertCurrenyWords(model.Currency)
                });
            }
            catch (Exception ex)
            {
                return Ok(new ConvertWordsResult()
                {
                    Success = false,
                    ErrorMessage = ex.Message
                });
            }
        }

        #endregion
    }
}
