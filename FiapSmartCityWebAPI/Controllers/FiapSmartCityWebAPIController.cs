using Microsoft.AspNetCore.Mvc;

using FiapSmartCityWebAPI.Models;
using FiapSmartCityWebAPI.DAL;

namespace FiapSmartCityWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FiapSmartCityWebAPIController : ControllerBase
    {
        // GET localhost:7188/api/FiapSmartCityWebAPI/ProductType
        [HttpGet]
        [Route("ProductType")]
        public IActionResult Get()
        {
            try
            {
                return base.Ok(new ProductTypeDAL().GetAll());
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // GET localhost:7188/api/FiapSmartCityWebAPI/ProductType?id={}
        [HttpGet]
        [Route("ProductType/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                ProductTypeDAL dal = new ProductTypeDAL();
                ProductType productType = dal.GetOne(id);
                return Ok(productType);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // POST localhost:7188/api/FiapSmartCityWebAPI/ProductType
        [HttpPost(Name = "ProductType")]
        public IActionResult Post([FromBody] ProductType productType)
        {
            try
            {
                // Cria o objeto DAL
                ProductTypeDAL dal = new ProductTypeDAL();
                // Insere a informação do banco de dados
                dal.Create(productType);

                // Cria uma propriedade para efetuar a consulta da informação cadastrada
                string location = "https://localhost:7188/api/FiapSmartCityWebAPI";

                return Created(new Uri(location), productType);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // DELETE localhost:7188/api/FiapSmartCityWebAPI/ProductType?id={}
        [HttpDelete(Name = "ProductType")]
        public IActionResult Delete(int id)
        {
            try
            {
                ProductTypeDAL dal = new ProductTypeDAL();
                dal.Delete(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PUT or PATCH localhost:7188/api/FiapSmartCityWebAPI/ProductType?id={}
        [HttpPut(Name = "ProductType")]
        public IActionResult Put([FromBody] ProductType productType)
        {
            try
            {
                ProductTypeDAL dal = new ProductTypeDAL();
                dal.Update(productType);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}