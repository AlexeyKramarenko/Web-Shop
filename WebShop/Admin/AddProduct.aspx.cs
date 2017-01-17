using ApplicationCore.ApplicationServices;
using ApplicationCore.DomainModel;
using AutoMapper;
using WebShop.Admin.Models;
using WebShop.DAL.Interfaces;
using WebShop.DAL.POCO;
//using WebShop.Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebShop.Admin
{
    public partial class AddProduct : System.Web.UI.Page
    {
        [Inject]
        public IProductRepository productRepository { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        public NewProductViewModel InitFormView()
        {
            var model = new NewProductViewModel();
            model.Materials = productRepository.GetMaterials();
            model.MaterialID = 1;
            return model;
        }

        public void AddNewProduct(NewProductViewModel vm)
        {
            string[] formats = new string[] { "image/jpeg", "image/png", "image/bmp" };

            if (ModelState.IsValid)
            {
                FileUpload largeImgUpload = (FileUpload)formview.FindControl("largeImg");
                FileUpload thumbImgUpload = (FileUpload)formview.FindControl("thumbImg");

                if (largeImgUpload.HasFile && thumbImgUpload.HasFile)
                {
                    if (formats.Contains(largeImgUpload.PostedFile.ContentType) && formats.Contains(largeImgUpload.PostedFile.ContentType))
                    {
                        string largeFileName = Guid.NewGuid().ToString() + "_" + largeImgUpload.FileName;
                        string largeImagePath = Server.MapPath("~/Images/cords/") + largeFileName;
                        largeImgUpload.SaveAs(largeImagePath);
                        vm.LargeImgPath = "~/Images/cords/" + largeFileName;

                        string thumbImgName = Guid.NewGuid().ToString() + "_" + thumbImgUpload.FileName;
                        string thumbImagePath = Server.MapPath("~/Images/cords/thumbs/") + thumbImgName;
                        thumbImgUpload.SaveAs(thumbImagePath);
                        vm.ThumbImgPath = "~/Images/cords/thumbs/" + thumbImgName;

                        var product = Mapper.Map<NewProductViewModel, WebShop.DAL.POCO.Product>(vm);
                        productRepository.AddProduct(product);
                        int result = productRepository.Save();
                        if (result == 0)
                            ModelState.AddModelError("", "Возникли проблемы при добавлении товара.");
                    }
                    else
                        ModelState.AddModelError("fileUploadError1", "Допустимые форматы изображений: jpeg, png, bmp.");
                }
                else
                    ModelState.AddModelError("fileUploadError2", "Вы не выбрали изображения.");
            }
        }

    }
}