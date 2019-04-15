using System;
using System.Collections.Generic;
using System.Linq;
using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities;
using MangoPay.SDK.Entities.GET;
using MangoPay.SDK.Entities.POST;
using MangoPay.SDK.Entities.PUT;
using NUnit.Framework;

namespace MangoPay.SDK.Tests
{

    [TestFixture]
    public class ApiUboDeclarationTests : BaseTest
    {
        private MangoPayApi _mangopayApi;

        [SetUp]
        public void SetUp()
        {
            _mangopayApi = BuildNewMangoPayApi();
        }

        //UboDeclarations test
        [Test]
        public void ApiUboDeclaration_GetAll_UboDeclaration_Valid()
        {
            var userLegal = Api.Users.Create(CreateUserLegalPost());
            var uboDeclarationDto = Api.UboDeclarations.Create(userLegal.Id);
            
            ListPaginated<UboDeclarationDTO> result = null;
            Pagination pagination = new Pagination(1, 1);
            Assert.DoesNotThrow(()=> result = Api.UboDeclarations.GetUboDeclarationByUserId(userLegal.Id,pagination));
            Assert.NotNull(result);
            Assert.IsTrue(result.Count > 0);
            Assert.AreEqual(uboDeclarationDto.Id, result[0].Id);
        }

        [Test]
        public void ApiUboDeclaration_Get_UboDeclaration_Valid()
        {
            var userLegal = Api.Users.Create(CreateUserLegalPost());
            
            UboDeclarationDTO uboDeclaration = null;
            Assert.DoesNotThrow(()=> uboDeclaration = Api.UboDeclarations.Create(userLegal.Id));
            UboDeclarationDTO result = null;
            Assert.DoesNotThrow(()=>result = Api.UboDeclarations.GetUboDeclarationById(userLegal.Id,uboDeclaration.Id));
            Assert.NotNull(result);
            Assert.AreEqual(uboDeclaration.Id,result.Id);
        }

        [Test]
        public void ApiUboDeclaration_Create_UboDeclaration_Valid()
        {
            var userLegal = Api.Users.Create(CreateUserLegalPost());

            UboDeclarationDTO result = null;

            Assert.DoesNotThrow(() => result = Api.UboDeclarations.CreateUboDeclaration(null, userLegal.Id));
            Assert.That(result.Status == UboDeclarationType.CREATED);
            Assert.That(result.CreationDate != DateTime.MinValue);
        }

        [Test]
        public void ApiUboDeclaration_Update_UboDeclaration_Valid()
        {
            var userLegal = Api.Users.Create(CreateUserLegalPost());

            var uboDeclaration = Api.UboDeclarations.CreateUboDeclaration(null, userLegal.Id);

            List<UboPostDTO> ubopostDtos = UboPostDtoCollection;
            List<UboDTO> uboDtos = new List<UboDTO>();

            foreach (var uboPost in ubopostDtos)
            {
                var ubo = Api.UboDeclarations.CreateUbo(null, uboPost, userLegal.Id, uboDeclaration.Id);
                uboDtos.Add(ubo);
            }

            UboDeclarationPutDTO ubodeclarationPut = new UboDeclarationPutDTO
            {
                Id = uboDeclaration.Id,
                Status = UboDeclarationType.VALIDATION_ASKED,
                Message = "New Refused Message",
                Ubos = uboDtos.ToArray(),
                Reason = new UboRefusedReasonType[] {UboRefusedReasonType.MISSING_UBO}
            };

            UboDeclarationDTO result = null;

            Assert.DoesNotThrow(() =>
                result = Api.UboDeclarations.UpdateUboDeclaration(ubodeclarationPut, userLegal.Id, ubodeclarationPut.Id));
            Assert.That(result != null);
            Assert.That(result.Status == UboDeclarationType.VALIDATION_ASKED);
            Assert.That(result.CreationDate != DateTime.MinValue);
        }
        
        //Ubo tests

        [Test]
        public void ApiUbo_Create_Ubo_Valid()
        {
            var userLegal = Api.Users.Create(CreateUserLegalPost());
            var uboDeclaration = Api.UboDeclarations.CreateUboDeclaration(null, userLegal.Id);
            var uboDto = UboPostDtoCollection[0];
            UboDTO result = null;
            Assert.DoesNotThrow(()=>result = Api.UboDeclarations.CreateUbo(uboDto, userLegal.Id, uboDeclaration.Id));
            Assert.NotNull(result);
        }

        [Test]
        public void ApiUbo_Upload_Ubo_Valid()
        {
            var userLegal = Api.Users.Create(CreateUserLegalPost());
            var uboDeclaration = Api.UboDeclarations.CreateUboDeclaration(null, userLegal.Id);
            var uboDto = UboPostDtoCollection[1];
            var ubo = Api.UboDeclarations.CreateUbo(uboDto, userLegal.Id, uboDeclaration.Id);
            var uboPutDto = new UboPutDTO
            {
                FirstName = "JohnNatural1",
                LastName = "DoeNatural1",
                Birthday =  new DateTime(1985, 12, 21, 0, 0, 0),
                Nationality = CountryIso.DE,
                Address = new Address
                {
                    AddressLine1 = "Address line Natural1 1",
                    AddressLine2 = "Address line Natural1 2",
                    City = "CityNatural1",
                    Country = CountryIso.PL,
                    PostalCode = "11222",
                    Region = "RegionNatural1"
                },
                Birthplace = new Birthplace()
                {
                    City = "CityNatural1",
                    Country = CountryIso.PL,
                }
            };
            UboDTO result = null;
            Assert.DoesNotThrow(()=> result = Api.UboDeclarations.UpdateUbo(uboPutDto,userLegal.Id,uboDeclaration.Id,ubo.Id));
            Assert.NotNull(result);
            Assert.AreEqual(ubo.Id,result.Id);
            Assert.AreEqual(uboPutDto.FirstName,result.FirstName);
        }

        private static List<UboPostDTO> UboPostDtoCollection{
            get
            {
                return new List<UboPostDTO>
                {
                    new UboPostDTO()
                    {
                        FirstName = "JohnNatural1",
                        LastName = "DoeNatural1",
                        Birthday =  new DateTime(1985, 12, 21, 0, 0, 0),
                        Nationality = CountryIso.DE,
                        Address = new Address
                        {
                            AddressLine1 = "Address line Natural1 1",
                            AddressLine2 = "Address line Natural1 2",
                            City = "CityNatural1",
                            Country = CountryIso.PL,
                            PostalCode = "11222",
                            Region = "RegionNatural1"
                        },
                        Birthplace = new Birthplace()
                        {
                            City = "CityNatural1",
                            Country = CountryIso.PL,
                        }

                    },
                    new UboPostDTO()
                    {
                        FirstName = "JohnNatural2",
                        LastName = "DoeNatural2",
                        Birthday =  new DateTime(1985, 12, 21, 0, 0, 0),
                        Nationality = CountryIso.DE,
                        Address = new Address()
                        {
                            AddressLine1 = "Address line Natural1 1",
                            AddressLine2 = "Address line Natural1 2",
                            City = "CityNatural1",
                            Country = CountryIso.PL,
                            PostalCode = "11222",
                            Region = "RegionNatural1"
                        },
                        Birthplace = new Birthplace()
                        {
                            City = "CityNatural2",
                            Country = CountryIso.PL,
                        }

                    }
                };
            }
        }
    }
}