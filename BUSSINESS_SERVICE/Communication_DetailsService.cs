using DATA_LAYER.HRMSOUW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUSSINESS_ENTITIES;
using DATA_LAYER;
using System.Transactions;
using System.Globalization;

namespace BUSSINESS_SERVICE
{
    public class Communication_DetailsService:ICommunicationDetails
    {
         private readonly UOW _UOW;
         public Communication_DetailsService()
        {
            _UOW = new UOW();
        }
        public IEnumerable<CommunicationDetailsEntities> GetCommunicationDetailsById(int CommunicationDetailsId)
        {
            var Communicationdata = (from a in _UOW.EMP_COMMUNICATION_DETAILSRepository.GetAll()
                            where a.EMPLOYEE_ID == CommunicationDetailsId
                            select new CommunicationDetailsEntities
                            {
                                ID = a.ID,
                                EMPLOYEE_ID = a.EMPLOYEE_ID,
                                PERMANENT_ADDRESS = a.PERMANENT_ADDRESS,
                                MAILING_ADDRESS=a.MAILING_ADDRESS,
                                PERMANENT_ADDRESS_CITY = a.PERMANENT_ADDRESS_CITY,
                                PERMANENT_ADDRESS_STATE = a.PERMANENT_ADDRESS_STATE,
                                PERMANENT_ADDRESS_PIN = a.PERMANENT_ADDRESS_PIN,
                                MAILING_ADDRESS_CITY = a.MAILING_ADDRESS_CITY,
                                MAILING_ADDRESS_STATE = a.MAILING_ADDRESS_STATE,
                                MAILING_ADDRESS_PIN = a.MAILING_ADDRESS_PIN,
                                PHONE_NUMBER = a.PHONE_NUMBER,
                                MOBILE_NUMBER=a.MOBILE_NUMBER,
                                EMERGENCY_CONTACT_NUMBER = a.EMERGENCY_CONTACT_NUMBER,
                                PASSPORT_NUMBER = a.PASSPORT_NUMBER,
                                VALIDITY = a.PASSPORT_VALIDITY.HasValue ? a.PASSPORT_VALIDITY.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture) : null,
                                DRIVING_LICENCE_NUMBER = a.DRIVING_LICENCE_NUMBER,
                                PANCARD_NUMBER = a.PANCARD_NUMBER,
                                AADHAR_NUMBER = a.AADHAR_NUMBER,
                                PERSONAL_EMAIL = a.PERSONAL_EMAIL,
                                OFFICIAL_EMAIL = a.OFFICIAL_EMAIL,
                                OFFICIAL_MOBILE_NUMBER = a.OFFICIAL_MOBILE_NUMBER,
                                RELATIONSHIP = a.RELATIONSHIP
                            }).ToList();


            return Communicationdata;
        }

        public IEnumerable<CommunicationDetailsEntities> GetAllCommunicationDetails()
        {
            var Communicationdata = (from a in _UOW.EMP_COMMUNICATION_DETAILSRepository.GetAll()
                                     select new CommunicationDetailsEntities
                                     {
                                         ID = a.ID,
                                         EMPLOYEE_ID = a.EMPLOYEE_ID,
                                         PERMANENT_ADDRESS = a.PERMANENT_ADDRESS,
                                         MAILING_ADDRESS = a.MAILING_ADDRESS,
                                         PERMANENT_ADDRESS_CITY = a.PERMANENT_ADDRESS_CITY,
                                         PERMANENT_ADDRESS_STATE = a.PERMANENT_ADDRESS_STATE,
                                         PERMANENT_ADDRESS_PIN = a.PERMANENT_ADDRESS_PIN,
                                         MAILING_ADDRESS_CITY = a.MAILING_ADDRESS_CITY,
                                         MAILING_ADDRESS_STATE = a.MAILING_ADDRESS_STATE,
                                         MAILING_ADDRESS_PIN = a.MAILING_ADDRESS_PIN,
                                         PHONE_NUMBER = a.PHONE_NUMBER,
                                         MOBILE_NUMBER = a.MOBILE_NUMBER,
                                         EMERGENCY_CONTACT_NUMBER = a.EMERGENCY_CONTACT_NUMBER,
                                         PASSPORT_NUMBER = a.PASSPORT_NUMBER,
                                         PASSPORT_VALIDITY = a.PASSPORT_VALIDITY,
                                         DRIVING_LICENCE_NUMBER = a.DRIVING_LICENCE_NUMBER,
                                         PANCARD_NUMBER = a.PANCARD_NUMBER,
                                         AADHAR_NUMBER = a.AADHAR_NUMBER,
                                         PERSONAL_EMAIL = a.PERSONAL_EMAIL,
                                         OFFICIAL_EMAIL = a.OFFICIAL_EMAIL,
                                         OFFICIAL_MOBILE_NUMBER = a.OFFICIAL_MOBILE_NUMBER,
                                         RELATIONSHIP=a.RELATIONSHIP

                                     }).ToList();


            return Communicationdata;
        }

        public int CreateCommunicationDetails(CommunicationDetailsEntities CommunicationDetailsEntities)
        {

            if (CommunicationDetailsEntities != null)
            {
                var CommunicationDetails = _UOW.EMP_COMMUNICATION_DETAILSRepository.GetAll().ToList().Where(x => x.EMPLOYEE_ID == CommunicationDetailsEntities.EMPLOYEE_ID).FirstOrDefault();
               if (CommunicationDetails != null)
                {
                    if (CommunicationDetailsEntities.PERMANENT_ADDRESS != "" && CommunicationDetailsEntities.PERMANENT_ADDRESS != null)
                    {
                        CommunicationDetails.PERMANENT_ADDRESS = CommunicationDetailsEntities.PERMANENT_ADDRESS;
                    }
                    if (CommunicationDetailsEntities.PERMANENT_ADDRESS_CITY != "" && CommunicationDetailsEntities.PERMANENT_ADDRESS_CITY != null)
                    {
                        CommunicationDetails.PERMANENT_ADDRESS_CITY = CommunicationDetails.PERMANENT_ADDRESS_CITY;
                    }
                    if ( CommunicationDetailsEntities.PERMANENT_ADDRESS_STATE != null)
                    {
                        CommunicationDetails.PERMANENT_ADDRESS_STATE = CommunicationDetailsEntities.PERMANENT_ADDRESS_STATE;
                    }
                    if ( CommunicationDetailsEntities.PERMANENT_ADDRESS_PIN != null)
                    {
                        CommunicationDetails.PERMANENT_ADDRESS_PIN = CommunicationDetailsEntities.PERMANENT_ADDRESS_PIN;
                    }
                    if (CommunicationDetailsEntities.MAILING_ADDRESS != null && CommunicationDetailsEntities.MAILING_ADDRESS != "")
                    {
                        CommunicationDetails.MAILING_ADDRESS = CommunicationDetailsEntities.MAILING_ADDRESS;
                    }
                    if (CommunicationDetailsEntities.MAILING_ADDRESS_CITY != null && CommunicationDetailsEntities.MAILING_ADDRESS_CITY != "")
                    {
                        CommunicationDetails.MAILING_ADDRESS_CITY = CommunicationDetailsEntities.MAILING_ADDRESS_CITY;
                    }
                    if (CommunicationDetailsEntities.MAILING_ADDRESS_STATE != null)
                    {
                        CommunicationDetails.MAILING_ADDRESS_STATE = CommunicationDetailsEntities.MAILING_ADDRESS_STATE;
                    }
                    if (CommunicationDetailsEntities.MAILING_ADDRESS_PIN != null)
                    {
                        CommunicationDetails.MAILING_ADDRESS_PIN = CommunicationDetailsEntities.MAILING_ADDRESS_PIN;
                    }
                    if (CommunicationDetailsEntities.PHONE_NUMBER != "" && CommunicationDetailsEntities.PHONE_NUMBER != null)
                    {
                        CommunicationDetails.PHONE_NUMBER = CommunicationDetailsEntities.PHONE_NUMBER;
                    }
                    if (CommunicationDetailsEntities.MOBILE_NUMBER != "" && CommunicationDetailsEntities.MOBILE_NUMBER != null)
                    {
                        CommunicationDetails.MOBILE_NUMBER = CommunicationDetailsEntities.MOBILE_NUMBER;
                    }
                    if (CommunicationDetailsEntities.PASSPORT_NUMBER != null && CommunicationDetailsEntities.PASSPORT_NUMBER != "")
                    {
                        CommunicationDetails.PASSPORT_NUMBER = CommunicationDetailsEntities.PASSPORT_NUMBER;
                    }
                    if (CommunicationDetailsEntities.EMERGENCY_CONTACT_NUMBER != "" && CommunicationDetailsEntities.EMERGENCY_CONTACT_NUMBER != null)
                    {
                        CommunicationDetails.EMERGENCY_CONTACT_NUMBER = CommunicationDetailsEntities.EMERGENCY_CONTACT_NUMBER;
                    }
                    if (CommunicationDetailsEntities.RELATIONSHIP != "" && CommunicationDetailsEntities.RELATIONSHIP != null)
                    {
                        CommunicationDetails.RELATIONSHIP = CommunicationDetailsEntities.RELATIONSHIP;
                    }
                    if (CommunicationDetailsEntities.VALIDITY != null)
                    {
                        var VALdate = DateTime.ParseExact(CommunicationDetailsEntities.VALIDITY, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        CommunicationDetails.PASSPORT_VALIDITY = VALdate;
                    }
                    if (CommunicationDetailsEntities.DRIVING_LICENCE_NUMBER != null && CommunicationDetailsEntities.DRIVING_LICENCE_NUMBER != "")
                    {
                        CommunicationDetails.DRIVING_LICENCE_NUMBER = CommunicationDetailsEntities.DRIVING_LICENCE_NUMBER;
                    }
                    if (CommunicationDetailsEntities.PANCARD_NUMBER != null && CommunicationDetailsEntities.PANCARD_NUMBER != "")
                    {
                        CommunicationDetails.PANCARD_NUMBER = CommunicationDetailsEntities.PANCARD_NUMBER;
                    }
                    if (CommunicationDetailsEntities.AADHAR_NUMBER != "" && CommunicationDetailsEntities.AADHAR_NUMBER != "")
                    {
                        CommunicationDetails.AADHAR_NUMBER = CommunicationDetailsEntities.AADHAR_NUMBER;
                    }
                    if (CommunicationDetailsEntities.PERSONAL_EMAIL != "" && CommunicationDetailsEntities.PERSONAL_EMAIL != "")
                    {
                        CommunicationDetails.PERSONAL_EMAIL = CommunicationDetailsEntities.PERSONAL_EMAIL;
                    }
                    if (CommunicationDetailsEntities.OFFICIAL_EMAIL != "" && CommunicationDetailsEntities.OFFICIAL_EMAIL != "")
                    {
                        CommunicationDetails.OFFICIAL_EMAIL = CommunicationDetailsEntities.OFFICIAL_EMAIL;
                    }
                    if (CommunicationDetailsEntities.OFFICIAL_MOBILE_NUMBER != null && CommunicationDetailsEntities.OFFICIAL_MOBILE_NUMBER != "")
                    {
                        CommunicationDetails.OFFICIAL_MOBILE_NUMBER = CommunicationDetailsEntities.OFFICIAL_MOBILE_NUMBER;
                    }

                    _UOW.EMP_COMMUNICATION_DETAILSRepository.Update(CommunicationDetails);
                    _UOW.Save();

                }
                else
                {
                    var VALdate = (DateTime?)null;
                    //DateTime joiningdate = Convert.ToDateTime(BasicinfoEntities.JOININGDATE);
                    if (CommunicationDetailsEntities.VALIDITY != null)
                    {
                        VALdate = DateTime.ParseExact(CommunicationDetailsEntities.VALIDITY, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    }
                    var CommunicationDetail = new TBL_EMP_COMMUNICATION_DETAILS
                    {
                        EMPLOYEE_ID = CommunicationDetailsEntities.EMPLOYEE_ID,
                        PERMANENT_ADDRESS = CommunicationDetailsEntities.PERMANENT_ADDRESS,
                        PERMANENT_ADDRESS_CITY=CommunicationDetailsEntities.PERMANENT_ADDRESS_CITY,
                        PERMANENT_ADDRESS_STATE=CommunicationDetailsEntities.PERMANENT_ADDRESS_STATE,
                        PERMANENT_ADDRESS_PIN=CommunicationDetailsEntities.PERMANENT_ADDRESS_PIN,
                        MAILING_ADDRESS=CommunicationDetailsEntities.MAILING_ADDRESS,
                        MAILING_ADDRESS_CITY=CommunicationDetailsEntities.MAILING_ADDRESS_CITY,
                        MAILING_ADDRESS_PIN=CommunicationDetailsEntities.MAILING_ADDRESS_PIN,
                        MAILING_ADDRESS_STATE=CommunicationDetailsEntities.MAILING_ADDRESS_STATE,
                        MOBILE_NUMBER=CommunicationDetailsEntities.MOBILE_NUMBER,
                        PHONE_NUMBER=CommunicationDetailsEntities.PHONE_NUMBER,
                        EMERGENCY_CONTACT_NUMBER=CommunicationDetailsEntities.EMERGENCY_CONTACT_NUMBER,
                        RELATIONSHIP=CommunicationDetailsEntities.RELATIONSHIP,
                        PASSPORT_NUMBER = CommunicationDetailsEntities.PASSPORT_NUMBER,
                        PASSPORT_VALIDITY = VALdate,
                        DRIVING_LICENCE_NUMBER=CommunicationDetailsEntities.DRIVING_LICENCE_NUMBER,
                        PANCARD_NUMBER=CommunicationDetailsEntities.PANCARD_NUMBER,
                       AADHAR_NUMBER=CommunicationDetailsEntities.AADHAR_NUMBER,
                       PERSONAL_EMAIL=CommunicationDetailsEntities.PERSONAL_EMAIL,
                       OFFICIAL_EMAIL=CommunicationDetailsEntities.OFFICIAL_EMAIL,
                       OFFICIAL_MOBILE_NUMBER=CommunicationDetailsEntities.OFFICIAL_MOBILE_NUMBER

                    };
                    _UOW.EMP_COMMUNICATION_DETAILSRepository.Insert(CommunicationDetail);
                    _UOW.Save();
                }
            }
            return Convert.ToInt32(CommunicationDetailsEntities.ID);
        }

        public bool UpdateCommunicationDetails(int CommunicationDetailsId, CommunicationDetailsEntities CommunicationDetailsEntities)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCommunicationDetails(int CommunicationDetailsId)
        {
            throw new NotImplementedException();
        }
    }
}
