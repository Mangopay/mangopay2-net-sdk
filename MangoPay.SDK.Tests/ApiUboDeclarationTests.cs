using System;
using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities;
using MangoPay.SDK.Entities.GET;
using MangoPay.SDK.Entities.POST;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using MangoPay.SDK.Entities.PUT;

namespace MangoPay.SDK.Tests
{

	[TestFixture]
	public class ApiUboDeclarationTests : BaseTest
	{
		private MangoPayApi _mangopayApi;

		private List<UserNaturalDTO> _userNaturalCollection;

		public List<UserNaturalDTO> UserNaturallCollection
		{
			get
			{
				if (_userNaturalCollection == null)
				{
					_userNaturalCollection = new List<UserNaturalDTO>();
				}

				return _userNaturalCollection;
			}
			set
			{
				_userNaturalCollection = value;
			}
		}

		private List<UserNaturalPostDTO> UserNaturalPostCollection
		{
			get
			{
				return new List<UserNaturalPostDTO>(){
				  new UserNaturalPostDTO(
				  "john.doenatural@natual1.com",
				  "JohnNatural1",
				  "DoeNatural1",
				  new DateTime(1985, 12, 21, 0, 0, 0),
				  CountryIso.DE,
				  CountryIso.DE,
				  CapacityType.DECLARATIVE)
				  {
					Address = new Address()
					{
						AddressLine1 = "Address line Natural1 1",
						AddressLine2 = "Address line Natural1 2",
						City = "CityNatural1",
						Country = CountryIso.PL,
						PostalCode = "11222",
						Region = "RegionNatural1"
					},
					Occupation = "programmer1",
					IncomeRange = 5
				  },

					new UserNaturalPostDTO(
					"john.doenatural@natual2.com",
					"JohnNatural2",
					"DoeNatural2",
					new DateTime(1985, 12, 21, 0, 0, 0),
					CountryIso.DE,
					CountryIso.DE,
					CapacityType.DECLARATIVE)
					{
					Address = new Address()
					{
						AddressLine1 = "Address line Natural2 1",
						AddressLine2 = "Address line Natural2 2",
						City = "CityNatural2",
						Country = CountryIso.PL,
						PostalCode = "11222",
						Region = "RegionNatural2"
					},
					Occupation = "programmer2",
					IncomeRange = 3
					}
				};
			}
		}

		private UboRefusedReasonType[] RefusedReasons
		{
			get
			{
				return new UboRefusedReasonType[] {
		  UboRefusedReasonType.INVALID_DECLARED_UBO,
		  UboRefusedReasonType.INVALID_UBO_DETAILS
		};
			}
		}

		[SetUp]
		public void SetUp()
		{
			_mangopayApi = BuildNewMangoPayApi();
		}

		[Test]
		public void ApiUboDeclaration_Create_UboDeclaration_Valid()
		{
			CreateUserNaturalPost();

			var userLegal = Api.Users.Create(CreateUserLegalPost());

			var uboDeclarationPost = CreateUboDeclarationPost(userLegal, RefusedReasons);

			UboDeclarationDTO result = null;

			Assert.DoesNotThrow(() => result = Api.UboDeclarations.Create(null, uboDeclarationPost));
			Assert.That(result.Status == UboDeclarationType.CREATED);
			Assert.That(result.CreationDate != DateTime.MinValue);
		}

		[Test]
		public void ApiUboDeclaration_Update_UboDeclaration_Valid()
		{
			CreateUserNaturalPost();

			var userLegal = Api.Users.Create(CreateUserLegalPost());

			var uboDeclarationPost = CreateUboDeclarationPost(userLegal, RefusedReasons);

			var uboDeclaration = Api.UboDeclarations.Create(null, uboDeclarationPost);

			UboDeclarationPutDTO ubodeclarationPut = new UboDeclarationPutDTO()
			{
				ID = uboDeclaration.Id,
				Status = UboDeclarationType.VALIDATION_ASKED,
				RefusedReasonMessage = "New Refused Message",
				RefusedReasonTypes = new UboRefusedReasonType[] { UboRefusedReasonType.MISSING_UBO }
			};

			UboDeclarationDTO result = null;

			Assert.DoesNotThrow(() => result = Api.UboDeclarations.Update(ubodeclarationPut));
			Assert.That(result != null);
			Assert.That(result.Status == UboDeclarationType.VALIDATION_ASKED);
			Assert.That(result.CreationDate != DateTime.MinValue);
		}

		private UboDeclarationPostDTO CreateUboDeclarationPost(UserLegalDTO userLegal, UboRefusedReasonType[] refusedResons)
		{
			return new UboDeclarationPostDTO(refusedResons, "Refused Reason Message")
			{
				UserId = userLegal.Id,
				Status = UboDeclarationType.CREATED,
				DeclaredUBOs = UserNaturallCollection.Select(x => x.Id).ToArray()
			};
		}

		private void CreateUserNaturalPost()
		{
			List<UserNaturalPostDTO> userNaturalCollection = UserNaturalPostCollection;

			foreach (var user in userNaturalCollection)
			{
				var userNatural = Api.Users.Create(user);
				UserNaturallCollection.Add(userNatural);
			}
		}

		private static UserLegalPostDTO CreateUserLegalPost()
		{
			UserLegalPostDTO user = new UserLegalPostDTO(
			  "john.doe@sample.org",
			  "MartixSampleOrg",
			  LegalPersonType.BUSINESS,
			  "JohnUbo",
			  "DoeUbo",
			  new DateTime(1975, 12, 21, 0, 0, 0),
			  CountryIso.PL,
			  CountryIso.PL);

			user.HeadquartersAddress = new Address
			{
				AddressLine1 = "Address line ubo 1",
				AddressLine2 = "Address line ubo 2",
				City = "CityUbo",
				Country = CountryIso.PL,
				PostalCode = "11222",
				Region = "RegionUbo"
			};

			user.LegalRepresentativeAddress = new Address
			{
				AddressLine1 = "Address line ubo 1",
				AddressLine2 = "Address line ubo 2",
				City = "CityUbo",
				Country = CountryIso.PL,
				PostalCode = "11222",
				Region = "RegionUbo"
			};

			user.LegalRepresentativeEmail = "john.doe@sample.org";
			user.LegalRepresentativeBirthday = new DateTime(1975, 12, 21, 0, 0, 0);
			user.Email = "john.doe@sample.org";
			return user;
		}

		[TearDown]
		public void TearDown()
		{

		}
	}
}
