using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATA_LAYER.HRMSGR;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace DATA_LAYER.HRMSOUW
{
    public class UOW : IDisposable
    {
        #region Private member variables...
        private HRMSEntities _context = null;
        private GenericRepository<TBL_DIVISION> _DIVISIONRepository;
        private GenericRepository<TBL_SUB_DIVISION> _SUBDIVISIONRepository;
        private GenericRepository<TBL_EMP_BASICINFO> _EMP_BASICINFORepository;
        private GenericRepository<TBL_SECTION> _SECTIONORepository;
        private GenericRepository<TBL_HRMS_DESIGNATIONMASTER> _DESIGNATIONRepository;
        private GenericRepository<TBL_HRMS_DEPARTMENTMASTER> _DEPARTMENTRepository;
        private GenericRepository<TBL_HRMS_REPORTINGMASTER> _REPORTINGRepository;
        private GenericRepository<TBL_HRMS_GRADE_MASTER> _GRADERepository;
        private GenericRepository<TBL_HRMS_EXITTYPE_MASTER> _EXITTYPERepository;
        private GenericRepository<TBL_COUNTRY> _COUNTRYRepository;
        private GenericRepository<TBL_STATE> _STATERepository;
        private GenericRepository<TBL_HRMS_BOARD_UNIVERSITY_M> _BOARD_UNIVERSITYRepository;
        private GenericRepository<TBL_HRMS_DEGREETYPE_MASTER> _DEGREETYPERepository;
        private GenericRepository<TBL_HRMS_BLOODGROUP_MASTER> _BLOODGROUPRepository;
        private GenericRepository<TBL_EMP_COMMUNICATION_DETAILS> _EMP_COMMUNICATION_DETAILSRepository;
        private GenericRepository<TBL_EMP_QUALIFICATION_DETAILS> _EMP_QUALIFICATION_DETAILSRepository;
        private GenericRepository<TBL_EMP_EMPLOYMENT_RECORD> _EMPLOYMENT_RECORDRepository;
        private GenericRepository<TBL_EMP_RELATIONSHIP_DETAILS> _RELATIONSHIP_DETAILSRepository;
        private GenericRepository<TBL_EMP_PIPDETAILS> _PIPDETAILSRepository;
        private GenericRepository<TBL_EMP_ASSETDETAILS> _EMP_ASSETDETAILSRepository;
        private GenericRepository<TBL_HRMS_LOCATIONMASTER> _LOCATIONMASTERRepository;
        private GenericRepository<TBL_EMP_TRANSFER_DETAILS> _TRANSFER_DETAILSMASTERRepository;
        private GenericRepository<TBL_HRMS_EXITSUBCATAGORY> _EXITSUBCATAGORYRepository;
        private GenericRepository<TBL_EMP_SALARYACCOUNTDETAILS> _SALARYACCOUNTDETAILSRepository;
        private GenericRepository<TBL_HRMS_ASSET_MASTER> _ASSET_MASTERRepository;
        private GenericRepository<TBL_HRMS_ASSETTYPE_MASTER> _ASSETTYPE_MASTERRepository;
        private GenericRepository<TBL_EMP_TRAINING_DETAILS> _TRAINING_DETAILSRepository;
        private GenericRepository<TBL_EMP_EXTRACULMACTIVITY> _EXTRACULMACTIVITYRepository;
        private GenericRepository<USER> _USERRepository;
        private GenericRepository<TBL_EMP_AWARDS> _AWARDSRepository;
        private GenericRepository<TBL_EMP_CULTURAL_ACTIVITYDTLS> _CULTURAL_ACTIVITYDTLSRepository;
        private GenericRepository<TBL_EMP_HOBBIES> _HOBBIESRepository;
        private GenericRepository<TBL_EMP_PUBLICATIONS> _PUBLICATIONSRepository;
        private GenericRepository<TBL_EMP_SOCIALACTIVITIES> _SOCIALACTIVITIESRepository;
        private GenericRepository<TBL_EMP_SPORTSDETAILS> _SPORTSDETAILSRepository;  
        //private GenericRepository<Token> _tokenRepository;
        #endregion

        public UOW()
        {
            _context = new HRMSEntities();
        }

        #region Public Repository Creation properties...
        public GenericRepository<TBL_EMP_AWARDS> AWARDSRepository
        {
            get
            {
                if (this._AWARDSRepository == null)
                    this._AWARDSRepository = new GenericRepository<TBL_EMP_AWARDS>(_context);
                return _AWARDSRepository;
            }
        }
        public GenericRepository<TBL_EMP_CULTURAL_ACTIVITYDTLS> CULTURAL_ACTIVITYDTLSRepository
        {
            get
            {
                if (this._CULTURAL_ACTIVITYDTLSRepository == null)
                    this._CULTURAL_ACTIVITYDTLSRepository = new GenericRepository<TBL_EMP_CULTURAL_ACTIVITYDTLS>(_context);
                return _CULTURAL_ACTIVITYDTLSRepository;
            }
        }
        public GenericRepository<TBL_EMP_HOBBIES> HOBBIESRepository
        {
            get
            {
                if (this._HOBBIESRepository == null)
                    this._HOBBIESRepository = new GenericRepository<TBL_EMP_HOBBIES>(_context);
                return _HOBBIESRepository;
            }
        }
        public GenericRepository<TBL_EMP_PUBLICATIONS> PUBLICATIONSRepository
        {
            get
            {
                if (this._PUBLICATIONSRepository == null)
                    this._PUBLICATIONSRepository = new GenericRepository<TBL_EMP_PUBLICATIONS>(_context);
                return _PUBLICATIONSRepository;
            }
        }
        public GenericRepository<TBL_EMP_SOCIALACTIVITIES> SOCIALACTIVITIESRepository
        {
            get
            {
                if (this._SOCIALACTIVITIESRepository == null)
                    this._SOCIALACTIVITIESRepository = new GenericRepository<TBL_EMP_SOCIALACTIVITIES>(_context);
                return _SOCIALACTIVITIESRepository;
            }
        }
        public GenericRepository<TBL_EMP_SPORTSDETAILS> SPORTSDETAILSRepository
        {
            get
            {
                if (this._SPORTSDETAILSRepository == null)
                    this._SPORTSDETAILSRepository = new GenericRepository<TBL_EMP_SPORTSDETAILS>(_context);
                return _SPORTSDETAILSRepository;
            }
        }
        public GenericRepository<USER> USERRepository
        {
            get
            {
                if (this._USERRepository == null)
                    this._USERRepository = new GenericRepository<USER>(_context);
                return _USERRepository;
            }
        }
        public GenericRepository<TBL_EMP_TRAINING_DETAILS> TRAINING_DETAILSRepository
        {
            get
            {
                if (this._TRAINING_DETAILSRepository == null)
                    this._TRAINING_DETAILSRepository = new GenericRepository<TBL_EMP_TRAINING_DETAILS>(_context);
                return _TRAINING_DETAILSRepository;
            }
        }
        public GenericRepository<TBL_EMP_EXTRACULMACTIVITY> EXTRACULMACTIVITYRepository
        {
            get
            {
                if (this._EXTRACULMACTIVITYRepository == null)
                    this._EXTRACULMACTIVITYRepository = new GenericRepository<TBL_EMP_EXTRACULMACTIVITY>(_context);
                return _EXTRACULMACTIVITYRepository;
            }
        }
        public GenericRepository<TBL_HRMS_ASSET_MASTER> ASSET_MASTERRepository
        {
            get
            {
                if (this._ASSET_MASTERRepository == null)
                    this._ASSET_MASTERRepository = new GenericRepository<TBL_HRMS_ASSET_MASTER>(_context);
                return _ASSET_MASTERRepository;
            }
        }
        public GenericRepository<TBL_HRMS_ASSETTYPE_MASTER> ASSETTYPE_MASTERRepository
        {
            get
            {
                if (this._ASSETTYPE_MASTERRepository == null)
                    this._ASSETTYPE_MASTERRepository = new GenericRepository<TBL_HRMS_ASSETTYPE_MASTER>(_context);
                return _ASSETTYPE_MASTERRepository;
            }
        }
        public GenericRepository<TBL_HRMS_EXITSUBCATAGORY> EXITSUBCATAGORYRepository
        {
            get
            {
                if (this._EXITSUBCATAGORYRepository == null)
                    this._EXITSUBCATAGORYRepository = new GenericRepository<TBL_HRMS_EXITSUBCATAGORY>(_context);
                return _EXITSUBCATAGORYRepository;
            }
        }
        public GenericRepository<TBL_EMP_SALARYACCOUNTDETAILS> SALARYACCOUNTDETAILSRepository
        {
            get
            {
                if (this._SALARYACCOUNTDETAILSRepository == null)
                    this._SALARYACCOUNTDETAILSRepository = new GenericRepository<TBL_EMP_SALARYACCOUNTDETAILS>(_context);
                return _SALARYACCOUNTDETAILSRepository;
            }
        }
        public GenericRepository<TBL_EMP_TRANSFER_DETAILS> TRANSFER_DETAILSMASTERRepository
        {
            get
            {
                if (this._TRANSFER_DETAILSMASTERRepository == null)
                    this._TRANSFER_DETAILSMASTERRepository = new GenericRepository<TBL_EMP_TRANSFER_DETAILS>(_context);
                return _TRANSFER_DETAILSMASTERRepository;
            }
        }
        public GenericRepository<TBL_HRMS_LOCATIONMASTER> LOCATIONMASTERRepository
        {
            get
            {
                if (this._LOCATIONMASTERRepository == null)
                    this._LOCATIONMASTERRepository = new GenericRepository<TBL_HRMS_LOCATIONMASTER>(_context);
                return _LOCATIONMASTERRepository;
            }
        }
        public GenericRepository<TBL_EMP_PIPDETAILS> PIPDETAILSRepository
        {
            get
            {
                if (this._PIPDETAILSRepository == null)
                    this._PIPDETAILSRepository = new GenericRepository<TBL_EMP_PIPDETAILS>(_context);
                return _PIPDETAILSRepository;
            }
        }
        public GenericRepository<TBL_EMP_ASSETDETAILS> EMP_ASSETDETAILSRepository
        {
            get
            {
                if (this._EMP_ASSETDETAILSRepository == null)
                    this._EMP_ASSETDETAILSRepository = new GenericRepository<TBL_EMP_ASSETDETAILS>(_context);
                return _EMP_ASSETDETAILSRepository;
            }
        }
        public GenericRepository<TBL_EMP_RELATIONSHIP_DETAILS> RELATIONSHIP_DETAILSRepository
        {
            get
            {
                if (this._RELATIONSHIP_DETAILSRepository == null)
                    this._RELATIONSHIP_DETAILSRepository = new GenericRepository<TBL_EMP_RELATIONSHIP_DETAILS>(_context);
                return _RELATIONSHIP_DETAILSRepository;
            }
        }
        public GenericRepository<TBL_EMP_COMMUNICATION_DETAILS> EMP_COMMUNICATION_DETAILSRepository
        {
            get
            {
                if (this._EMP_COMMUNICATION_DETAILSRepository == null)
                    this._EMP_COMMUNICATION_DETAILSRepository = new GenericRepository<TBL_EMP_COMMUNICATION_DETAILS>(_context);
                return _EMP_COMMUNICATION_DETAILSRepository;
            }
        }
        public GenericRepository<TBL_EMP_QUALIFICATION_DETAILS> EMP_QUALIFICATION_DETAILSRepository
        {
            get
            {
                if (this._EMP_QUALIFICATION_DETAILSRepository == null)
                    this._EMP_QUALIFICATION_DETAILSRepository = new GenericRepository<TBL_EMP_QUALIFICATION_DETAILS>(_context);
                return _EMP_QUALIFICATION_DETAILSRepository;
            }
        }
        public GenericRepository<TBL_EMP_EMPLOYMENT_RECORD> EMPLOYMENT_RECORDRepository
        {
            get
            {
                if (this._EMPLOYMENT_RECORDRepository == null)
                    this._EMPLOYMENT_RECORDRepository = new GenericRepository<TBL_EMP_EMPLOYMENT_RECORD>(_context);
                return _EMPLOYMENT_RECORDRepository;
            }
        }
        public GenericRepository<TBL_HRMS_BLOODGROUP_MASTER> BLOODGROUPRepository
        {
            get
            {
                if (this._BLOODGROUPRepository == null)
                    this._BLOODGROUPRepository = new GenericRepository<TBL_HRMS_BLOODGROUP_MASTER>(_context);
                return _BLOODGROUPRepository;
            }
        }
        public GenericRepository<TBL_HRMS_DEGREETYPE_MASTER> DEGREETYPERepository
        {
            get
            {
                if (this._DEGREETYPERepository == null)
                    this._DEGREETYPERepository = new GenericRepository<TBL_HRMS_DEGREETYPE_MASTER>(_context);
                return _DEGREETYPERepository;
            }
        }
        public GenericRepository<TBL_HRMS_BOARD_UNIVERSITY_M> BOARD_UNIVERSITYRepository
        {
            get
            {
                if (this._BOARD_UNIVERSITYRepository == null)
                    this._BOARD_UNIVERSITYRepository = new GenericRepository<TBL_HRMS_BOARD_UNIVERSITY_M>(_context);
                return _BOARD_UNIVERSITYRepository;
            }
        }
        public GenericRepository<TBL_STATE> STATERepository
        {
            get
            {
                if (this._STATERepository == null)
                    this._STATERepository = new GenericRepository<TBL_STATE>(_context);
                return _STATERepository;
            }
        }
        public GenericRepository<TBL_COUNTRY> COUNTRYRepository
        {
            get
            {
                if (this._COUNTRYRepository == null)
                    this._COUNTRYRepository = new GenericRepository<TBL_COUNTRY>(_context);
                return _COUNTRYRepository;
            }
        }
        public GenericRepository<TBL_HRMS_EXITTYPE_MASTER> EXITTYPERepository
        {
            get
            {
                if (this._EXITTYPERepository == null)
                    this._EXITTYPERepository = new GenericRepository<TBL_HRMS_EXITTYPE_MASTER>(_context);
                return _EXITTYPERepository;
            }
        }
        public GenericRepository<TBL_HRMS_GRADE_MASTER> GRADERepository
        {
            get
            {
                if (this._GRADERepository == null)
                    this._GRADERepository = new GenericRepository<TBL_HRMS_GRADE_MASTER>(_context);
                return _GRADERepository;
            }
        }
        public GenericRepository<TBL_HRMS_REPORTINGMASTER> REPORTINGRepository
        {
            get
            {
                if (this._REPORTINGRepository == null)
                    this._REPORTINGRepository = new GenericRepository<TBL_HRMS_REPORTINGMASTER>(_context);
                return _REPORTINGRepository;
            }
        }
        public GenericRepository<TBL_HRMS_DEPARTMENTMASTER> DEPARTMENTRepository
        {
            get
            {
                if (this._DEPARTMENTRepository == null)
                    this._DEPARTMENTRepository = new GenericRepository<TBL_HRMS_DEPARTMENTMASTER>(_context);
                return _DEPARTMENTRepository;
            }
        }
        public GenericRepository<TBL_HRMS_DESIGNATIONMASTER> DESIGNATIONRepository
        {
            get
            {
                if (this._DESIGNATIONRepository == null)
                    this._DESIGNATIONRepository = new GenericRepository<TBL_HRMS_DESIGNATIONMASTER>(_context);
                return _DESIGNATIONRepository;
            }
        }
        public GenericRepository<TBL_SECTION> SECTIONORepository
        {
            get
            {
                if (this._SECTIONORepository == null)
                    this._SECTIONORepository = new GenericRepository<TBL_SECTION>(_context);
                return _SECTIONORepository;
            }
        }
        public GenericRepository<TBL_SUB_DIVISION> SUBDIVISIONRepository
        {
            get
            {
                if (this._SUBDIVISIONRepository == null)
                    this._SUBDIVISIONRepository = new GenericRepository<TBL_SUB_DIVISION>(_context);
                return _SUBDIVISIONRepository;
            }
        }
        public GenericRepository<TBL_DIVISION> DIVISIONRepository
        {
            get
            {
                if (this._DIVISIONRepository == null)
                    this._DIVISIONRepository = new GenericRepository<TBL_DIVISION>(_context);
                return _DIVISIONRepository;
            }
        }
        public GenericRepository<TBL_EMP_BASICINFO> EMP_BASICINFORepository
        {
            get
            {
                if (this._EMP_BASICINFORepository == null)
                    this._EMP_BASICINFORepository = new GenericRepository<TBL_EMP_BASICINFO>(_context);
                return _EMP_BASICINFORepository;
            }
        }
        /// <summary>
        /// Get/Set Property for product repository.
        /// </summary>
        /// 

        #endregion

        #region Public member methods...
        /// <summary>
        /// Save method.
        /// </summary>
        public void Save()
        {
            try
            {

                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {

                var outputLines = new List<string>();
                foreach (var eve in e.EntityValidationErrors)
                {
                    outputLines.Add(string.Format(
                        "{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:", DateTime.Now,
                        eve.Entry.Entity.GetType().Name, eve.Entry.State));
                    foreach (var ve in eve.ValidationErrors)
                    {
                        outputLines.Add(string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage));
                    }
                }
                System.IO.File.AppendAllLines(@"D:\errors.txt", outputLines);

                throw e;
            }
            catch (Exception e)
            {

                var outputLines = new List<string>();
                foreach (var eve in e.Message)
                {
                    outputLines.Add(string.Format(
                        "{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:", DateTime.Now,
                        e.Message, e.StackTrace));
                    //foreach (var ve in eve.ValidationErrors)
                    //{
                    //    outputLines.Add(string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage));
                    //}
                }
                System.IO.File.AppendAllLines(@"D:\errors.txt", outputLines);

                throw e;
            }
        }

        #endregion

        #region Implementing IDiosposable...

        #region private dispose variable declaration...
        private bool disposed = false;
        #endregion

        /// <summary>
        /// Protected Virtual Dispose method
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Debug.WriteLine("UnitOfWork is being disposed");
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        /// <summary>
        /// Dispose method
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
