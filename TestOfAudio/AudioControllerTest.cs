using AudioAPP;
using AudioAPP.Controllers;
using AudioAPP.Data.Repository.Repository;
using Microsoft.AspNetCore.Mvc;
using AudioAPP.Models;

namespace TestOfAudio
{
    public class AudioControllerTest
    {
        private readonly AudiosController _controller;
        private readonly IRepository _service;
        public AudioControllerTest()
        {
            this._service = new AudioServiceTest();
            this._controller = new AudiosController(this._service);
            _service.Save(new Audio() { Title = "Test", Description = "asdsad", Sound = "asdsadas" });
            _service.Save(new Audio() { Title = "Test", Description = "asdsad", Sound = "asdsadas" });
            _service.Save(new Audio() { Title = "Test", Description = "asdsad", Sound = "asdsadas" });
            _service.Save(new Audio() { Title = "Test", Description = "asdsad", Sound = "asdsadas" });
            _service.Save(new Audio() { Title = "Test", Description = "asdsad", Sound = "asdsadas" });
            _service.Save(new Audio() { Title = "Test", Description = "asdsad", Sound = "asdsadas" });
        }
        [Fact]
        public void GetTest()
        {
            var actionResult = _service.FindAll();
            List<Audio> audios = new List<Audio>(actionResult);
            Assert.Equal(actionResult.Count(), audios.Count);
        }
        [Fact]
        public void GetIdTest()
        {
            var actionResult = _controller.Get(1);
            Audio audio = Assert.IsType<Audio>(actionResult.Value);
            Assert.Equal(audio.Id, _service.FindBy(audio.Id).Id);
            var actionResult1 = _controller.Get(50);
            Assert.IsType<NotFoundResult>(actionResult1.Result);
        }
        [Fact]
        public void PostTest()
        {
            Audio audio2 = new Audio()
            {
                Title = "Title",
                Description = "Test1",
                Sound = "Test2"
            };
            Audio audio3 = null;

            var actionResult = _controller.Post(audio2);
            Assert.IsType<CreatedResult>(actionResult.Result);
            var actionResult1 = _controller.Post(audio3);
            Assert.IsType<BadRequestResult>(actionResult1.Result);
        }
        [Fact]
        public void DeleteTest()
        {

            var Test1 =_controller.Delete(1);
            var Test2 =_controller.Delete(45);
            Assert.IsType<NoContentResult>(Test1);
            Assert.IsType<NotFoundResult>(Test2);
        }
        [Fact]
        public void PutTest()
        {
            Audio? audio = _controller.Get(2).Value;
            string audioDescription = audio.Description;
            audio.Description = "Ciekawamuzyka";
            _controller.Put(2, audio);
            Audio? audioUpdated = _controller.Get(2).Value;
            Assert.Equal("Ciekawamuzyka", audioUpdated.Description);
            Assert.NotEqual(audioDescription, audioUpdated.Description);
        }

    }
}