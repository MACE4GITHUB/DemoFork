﻿using BulbaCourses.PracticalMaterialsTests.Logic.Models.Test.AnswerVariants;
using BulbaCourses.PracticalMaterialsTests.Logic.Models.Test.Questions;
using BulbaCourses.PracticalMaterialsTests.Logic.Models.Test;
using BulbaCourses.PracticalMaterialsTests.Logic.Services.Test.Interface;
using Ninject;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BulbaCourses.PracticalMaterialsTests.Tests.Modules;
using BulbaCourses.PracticalMaterialsTests.Logic.Models.Common;
using BulbaCourses.PracticalMaterialsTests.Tests.DataGenerators;
using BulbaCourses.PracticalMaterialsTests.Logic.Models.User;

namespace BulbaCourses.PracticalMaterialsTests.Tests.Layers.Logic.Services
{
    [TestFixture]
    public class Service_Test_UnitTest
    {
        IService_Test _service_Test;

        [OneTimeSetUp]
        public void Init()
        {
            IKernel kernel = new StandardKernel(new[] { new ModuleNinject_Tests() });

            _service_Test = kernel.Get<IService_Test>();
        }

        [Test, MaxTime(2000)]
        [TestCase(1)]
        public void GetByIdTest(int Id)
        {
            Result<MTest_MainInfo> Test_MainInfo = _service_Test.GetById(Id);            

            Assert.Warn($@"{Test_MainInfo.Data.Id}");
        }

        [Test, MaxTime(2000)]
        [TestCase(1)]
        public void GetByIdAsyncTest(int Id)
        {
            Task<Result<MTest_MainInfo>> Test_MainInfo = _service_Test.GetByIdAsync(Id);            

            Assert.Warn($@"{Test_MainInfo.Result.Data.Questions_ChoosingAnswerFromList.FirstOrDefault().AnswerVariants.FirstOrDefault().AnswerText} || {Test_MainInfo.Result.Message}");
        }

        [Test, MaxTime(2000)]
        public void AddTest()
        {
            Result<MTest_MainInfo> Test_MainInfo = 
                _service_Test.Add(Generator_TestModels.Generate_MTest_MainInfo(1,4,4, new MUser_TestAuthor()).FirstOrDefault());
                     
            Assert.Warn($@"UserId: {Test_MainInfo.Data.User_TestAuthor.Id} | TestId: {Test_MainInfo.Data.Id}");           
        }

        [Test]
        public async Task AddAsyncTest()
        {
            var HasAdd = 
                await _service_Test.AddAsync(Generator_TestModels.Generate_MTest_MainInfo(1, 4, 4, new MUser_TestAuthor()).FirstOrDefault());

            Assert.Warn($@"ResultId: {HasAdd.Data.Id} || {HasAdd.Data.Name}");
        }

        [Test]
        public void DeleteById()
        {
            AddTest();

            var Test_MainInfo =  _service_Test.DeleteById(1);

            Assert.Warn($@"{Test_MainInfo.IsSuccess}");
        }

        [Test]
        public async Task DeleteByIdAsync()
        {
            var Test_MainInfo = await _service_Test.DeleteByIdAsync(1);

            Assert.Warn($@"{Test_MainInfo.IsSuccess}");
        }

        [Test]
        public void Update()
        {
            MTest_MainInfo TestData =
                new MTest_MainInfo()
                {
                    Name = "Test_Name_3",
                    Questions_ChoosingAnswerFromList =
                        new List<MQuestion_ChoosingAnswerFromList>()
                        {
                                new MQuestion_ChoosingAnswerFromList()
                                {
                                    QuestionText = "Question_ChoosingAnswerFromListDb_Text_1",
                                    SortKey = 1,
                                    AnswerVariants =
                                    new List<MAnswerVariant_ChoosingAnswerFromList>()
                                    {
                                        new MAnswerVariant_ChoosingAnswerFromList()
                                        {
                                            AnswerText = "AnswerText_1",
                                            SortKey = 1,
                                            IsCorrectAnswer = false
                                        },
                                        new MAnswerVariant_ChoosingAnswerFromList()
                                        {
                                            AnswerText = "AnswerText_2",
                                            SortKey = 2,
                                            IsCorrectAnswer = false
                                        },
                                        new MAnswerVariant_ChoosingAnswerFromList()
                                        {
                                            AnswerText = "AnswerText_3",
                                            SortKey = 3,
                                            IsCorrectAnswer = true
                                        }
                                    }
                                }
                        },
                    Questions_SetIntoMissingElements =
                        new List<MQuestion_SetIntoMissingElements>()
                        {
                            new MQuestion_SetIntoMissingElements()
                            {
                                QuestionText = "Question_SetIntoMissingElementsDb_Text_1",
                                SortKey = 2
                            }
                        },
                    Questions_SetOrder =
                        new List<MQuestion_SetOrder>()
                        {
                                new MQuestion_SetOrder()
                                {
                                    QuestionText = "QuestionText_1",
                                    SortKey = 3,
                                    AnswerVariants =
                                    new List<MAnswerVariant_SetOrder>()
                                    {
                                        new MAnswerVariant_SetOrder()
                                        {
                                            AnswerText = "AnswerText_1",
                                            SortKey = 1,
                                            CorrectOrderKey = 1
                                        },
                                        new MAnswerVariant_SetOrder()
                                        {
                                            AnswerText = "AnswerText_2",
                                            SortKey = 2,
                                            CorrectOrderKey = 2
                                        },
                                        new MAnswerVariant_SetOrder()
                                        {
                                            AnswerText = "AnswerText_3",
                                            SortKey = 3,
                                            CorrectOrderKey = 3
                                        }
                                    }
                                }
                        }

                };

            var Test_MainInfo = _service_Test.Update(TestData);

            Assert.Warn($@"{Test_MainInfo.Data.Name}");
        }

        [Test]
        public async Task UpdateAsync()
        {
            MTest_MainInfo TestData =
                new MTest_MainInfo()
                {
                    Id = 1,
                    Name = "Test_Name_2",
                    Questions_ChoosingAnswerFromList =
                        new List<MQuestion_ChoosingAnswerFromList>()
                        {
                                new MQuestion_ChoosingAnswerFromList()
                                {
                                    QuestionText = "Question_ChoosingAnswerFromListDb_Text_1",
                                    SortKey = 1,
                                    AnswerVariants =
                                    new List<MAnswerVariant_ChoosingAnswerFromList>()
                                    {
                                        new MAnswerVariant_ChoosingAnswerFromList()
                                        {
                                            AnswerText = "AnswerText_1",
                                            SortKey = 1,
                                            IsCorrectAnswer = false
                                        },
                                        new MAnswerVariant_ChoosingAnswerFromList()
                                        {
                                            AnswerText = "AnswerText_2",
                                            SortKey = 2,
                                            IsCorrectAnswer = false
                                        },
                                        new MAnswerVariant_ChoosingAnswerFromList()
                                        {
                                            AnswerText = "AnswerText_3",
                                            SortKey = 3,
                                            IsCorrectAnswer = true
                                        }
                                    }
                                }
                        },
                    Questions_SetIntoMissingElements =
                        new List<MQuestion_SetIntoMissingElements>()
                        {
                            new MQuestion_SetIntoMissingElements()
                            {
                                QuestionText = "Question_SetIntoMissingElementsDb_Text_1",
                                SortKey = 2
                            }
                        },
                    Questions_SetOrder =
                        new List<MQuestion_SetOrder>()
                        {
                                new MQuestion_SetOrder()
                                {
                                    QuestionText = "QuestionText_1",
                                    SortKey = 3,
                                    AnswerVariants =
                                    new List<MAnswerVariant_SetOrder>()
                                    {
                                        new MAnswerVariant_SetOrder()
                                        {
                                            AnswerText = "AnswerText_1",
                                            SortKey = 1,
                                            CorrectOrderKey = 1
                                        },
                                        new MAnswerVariant_SetOrder()
                                        {
                                            AnswerText = "AnswerText_2",
                                            SortKey = 2,
                                            CorrectOrderKey = 2
                                        },
                                        new MAnswerVariant_SetOrder()
                                        {
                                            AnswerText = "AnswerText_3",
                                            SortKey = 3,
                                            CorrectOrderKey = 3
                                        }
                                    }
                                }
                        }
                };


            var Test_MainInfo = await _service_Test.UpdateAsync(TestData);

            Assert.Warn($@"{Test_MainInfo.Data.Name}");
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            _service_Test.Dispose();
        }
    }
}
