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
    public class QualificationDetailsService : IQualificationDetails
    {
        private readonly UOW _UOW;
        public QualificationDetailsService()
        {
            _UOW = new UOW();
        }
        public IEnumerable<QualificationDetailsEntities> GetQualificationDetailseById(int QualificationDetailsId)
        {
            var qualificationdata = (from q in _UOW.EMP_QUALIFICATION_DETAILSRepository.GetAll()
                                     where q.EMPLOYEE_ID == QualificationDetailsId
                                     select new QualificationDetailsEntities
                                     {
                                         ID = q.ID,
                                         EMPLOYEE_ID = q.EMPLOYEE_ID,
                                         SCHOOL_COLLEGE_NAME = q.SCHOOL_COLLEGE_NAME,
                                         BOARD_UNIVERSITY_NAME = q.BOARD_UNIVERSITY_NAME,
                                         TYPE = q.TYPE,
                                         START_DATE = q.START_DATE,
                                         END_DATE = q.END_DATE,
                                         EXAM_DEGREE_TYPE = q.EXAM_DEGREE_TYPE,
                                         SUBJECT = q.SUBJECT,
                                         TOTAL_MARKS = q.TOTAL_MARKS,
                                         MARKS_SECURED = q.MARKS_SECURED,
                                         PERCENTAGE_OF_MARK_DIVISION = q.PERCENTAGE_OF_MARK_DIVISION,
                                     }
                                     ).ToList();
            return qualificationdata;
        }

        public IEnumerable<QualificationDetailsEntities> GetAllQualificationDetails()
        {
            var qualificationdata = (from q in _UOW.EMP_QUALIFICATION_DETAILSRepository.GetAll()
                                     select new QualificationDetailsEntities
                                     {
                                         ID = q.ID,
                                         EMPLOYEE_ID = q.EMPLOYEE_ID,
                                         SCHOOL_COLLEGE_NAME = q.SCHOOL_COLLEGE_NAME,
                                         BOARD_UNIVERSITY_NAME = q.BOARD_UNIVERSITY_NAME,
                                         TYPE = q.TYPE,
                                         START_DATE = q.START_DATE,
                                         END_DATE = q.END_DATE,
                                         EXAM_DEGREE_TYPE = q.EXAM_DEGREE_TYPE,
                                         SUBJECT = q.SUBJECT,
                                         TOTAL_MARKS = q.TOTAL_MARKS,
                                         MARKS_SECURED = q.MARKS_SECURED,
                                         PERCENTAGE_OF_MARK_DIVISION = q.PERCENTAGE_OF_MARK_DIVISION
                                     }
                                     ).ToList();
            return qualificationdata;
        }

        public int CreateQualificationDetails(QualificationDetailsEntities QualificationDetailsEntities)
        {
            //DateTime? enroldate = null;
            //DateTime? closeddate = null;
            var enroldate = (DateTime?)null;
            var closeddate = (DateTime?)null; 
            if (QualificationDetailsEntities.ENROLLEDDATE != null && QualificationDetailsEntities.ENROLLEDDATE != "")
            {
                enroldate = DateTime.ParseExact(QualificationDetailsEntities.ENROLLEDDATE, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            if (QualificationDetailsEntities.COMPLETEDDATE != null && QualificationDetailsEntities.COMPLETEDDATE != "")
            {
                closeddate = DateTime.ParseExact(QualificationDetailsEntities.COMPLETEDDATE, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            if (QualificationDetailsEntities != null)
            {
                //var QualificationDetails = _UOW.EMP_QUALIFICATION_DETAILSRepository.GetAll().Where(x => x.EMPLOYEE_ID == QualificationDetailsEntities.EMPLOYEE_ID && x.EXAM_DEGREE_TYPE == QualificationDetailsEntities.EXAM_DEGREE_TYPE).ToList().FirstOrDefault();

                //if (QualificationDetails != null)
                //{
                //    if (QualificationDetailsEntities.EMPLOYEE_ID != null)
                //    {
                //        QualificationDetails.EMPLOYEE_ID = QualificationDetailsEntities.EMPLOYEE_ID;
                //    }
                //    if (QualificationDetailsEntities.SCHOOL_COLLEGE_NAME != "" && QualificationDetailsEntities.SCHOOL_COLLEGE_NAME != null)
                //    {
                //        QualificationDetails.SCHOOL_COLLEGE_NAME = QualificationDetailsEntities.SCHOOL_COLLEGE_NAME;
                //    }

                //    if (QualificationDetailsEntities.BOARD_UNIVERSITY_NAME != null)
                //    {
                //        QualificationDetails.BOARD_UNIVERSITY_NAME = QualificationDetailsEntities.BOARD_UNIVERSITY_NAME;
                //    }
                //    if (QualificationDetailsEntities.TYPE != null && QualificationDetailsEntities.TYPE != "")
                //    {
                //        QualificationDetails.TYPE = QualificationDetailsEntities.TYPE;
                //    }

                //    if (QualificationDetailsEntities.ENROLLEDDATE != null && QualificationDetailsEntities.ENROLLEDDATE != "")
                //    {
                //        QualificationDetails.START_DATE = enroldate;
                //    }
                //    if (QualificationDetailsEntities.COMPLETEDDATE != null && QualificationDetailsEntities.COMPLETEDDATE != "")
                //    {
                //        QualificationDetails.END_DATE = closeddate;
                //    }
                //    if (QualificationDetailsEntities.EXAM_DEGREE_TYPE != null)
                //    {
                //        QualificationDetails.EXAM_DEGREE_TYPE = QualificationDetailsEntities.EXAM_DEGREE_TYPE;
                //    }
                //    if (QualificationDetailsEntities.SUBJECT != "" && QualificationDetailsEntities.SUBJECT != null)
                //    {
                //        QualificationDetails.SUBJECT = QualificationDetailsEntities.SUBJECT;
                //    }

                //    if (QualificationDetailsEntities.TOTAL_MARKS != null)
                //    {
                //        QualificationDetails.TOTAL_MARKS = QualificationDetailsEntities.TOTAL_MARKS;
                //    }
                //    if (QualificationDetailsEntities.MARKS_SECURED != null)
                //    {
                //        QualificationDetails.MARKS_SECURED = QualificationDetailsEntities.MARKS_SECURED;
                //    }
                //    if (QualificationDetailsEntities.PERCENTAGE_OF_MARK_DIVISION != null)
                //    {
                //        QualificationDetails.PERCENTAGE_OF_MARK_DIVISION = QualificationDetailsEntities.PERCENTAGE_OF_MARK_DIVISION;
                //    }

                //    _UOW.EMP_QUALIFICATION_DETAILSRepository.Update(QualificationDetails);
                //    _UOW.Save();

                //}
                //else
                //{
                    var QualificationDetail = new TBL_EMP_QUALIFICATION_DETAILS
                    {
                        EMPLOYEE_ID = QualificationDetailsEntities.EMPLOYEE_ID,
                        SCHOOL_COLLEGE_NAME = QualificationDetailsEntities.SCHOOL_COLLEGE_NAME,
                        BOARD_UNIVERSITY_NAME = QualificationDetailsEntities.BOARD_UNIVERSITY_NAME,
                        TYPE = QualificationDetailsEntities.TYPE,
                        START_DATE = enroldate,
                        END_DATE = closeddate,
                        EXAM_DEGREE_TYPE = QualificationDetailsEntities.EXAM_DEGREE_TYPE,
                        SUBJECT = QualificationDetailsEntities.SUBJECT,
                        TOTAL_MARKS = QualificationDetailsEntities.TOTAL_MARKS,
                        MARKS_SECURED = QualificationDetailsEntities.MARKS_SECURED,
                        PERCENTAGE_OF_MARK_DIVISION = QualificationDetailsEntities.PERCENTAGE_OF_MARK_DIVISION

                    };
                    _UOW.EMP_QUALIFICATION_DETAILSRepository.Insert(QualificationDetail);
                    _UOW.Save();
                //}
            }
            return Convert.ToInt32(QualificationDetailsEntities.ID);
        }

        public bool UpdateQualificationDetails(int QualificationDetailsId, QualificationDetailsEntities QualificationDetailsEntities)
        {
            var enroldate = (DateTime?)null;
            var closeddate = (DateTime?)null;
            if (QualificationDetailsEntities.ENROLLEDDATE != null && QualificationDetailsEntities.ENROLLEDDATE != "")
            {
                enroldate = DateTime.ParseExact(QualificationDetailsEntities.ENROLLEDDATE, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            if (QualificationDetailsEntities.COMPLETEDDATE != null && QualificationDetailsEntities.COMPLETEDDATE != "")
            {
                closeddate = DateTime.ParseExact(QualificationDetailsEntities.COMPLETEDDATE, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            var success = false;
            if (QualificationDetailsEntities != null)
            {
                //using (var scope = new TransactionScope())
                //{
               
               
                    //var QualificationDetails = _UOW.EMP_QUALIFICATION_DETAILSRepository.GetAll().Where(x => x.EMPLOYEE_ID == QualificationDetailsEntities.EMPLOYEE_ID && x.EXAM_DEGREE_TYPE == QualificationDetailsEntities.EXAM_DEGREE_TYPE).ToList().FirstOrDefault();
                    var QualificationDetails = _UOW.EMP_QUALIFICATION_DETAILSRepository.GetByID(QualificationDetailsId);
                    if (QualificationDetails != null)
                    {
                        if (QualificationDetailsEntities.EMPLOYEE_ID != null)
                        {
                            QualificationDetails.EMPLOYEE_ID = QualificationDetailsEntities.EMPLOYEE_ID;
                        }
                        if (QualificationDetailsEntities.SCHOOL_COLLEGE_NAME != "" && QualificationDetailsEntities.SCHOOL_COLLEGE_NAME != null)
                        {
                            QualificationDetails.SCHOOL_COLLEGE_NAME = QualificationDetailsEntities.SCHOOL_COLLEGE_NAME;
                        }

                        if (QualificationDetailsEntities.BOARD_UNIVERSITY_NAME != null)
                        {
                            QualificationDetails.BOARD_UNIVERSITY_NAME = QualificationDetailsEntities.BOARD_UNIVERSITY_NAME;
                        }
                        if (QualificationDetailsEntities.TYPE != null && QualificationDetailsEntities.TYPE != "")
                        {
                            QualificationDetails.TYPE = QualificationDetailsEntities.TYPE;
                        }

                        if (QualificationDetailsEntities.ENROLLEDDATE != null && QualificationDetailsEntities.ENROLLEDDATE != "")
                        {
                            QualificationDetails.START_DATE = enroldate;
                        }
                        if (QualificationDetailsEntities.COMPLETEDDATE != null && QualificationDetailsEntities.COMPLETEDDATE != "")
                        {
                            QualificationDetails.END_DATE = closeddate;
                        }
                        if (QualificationDetailsEntities.EXAM_DEGREE_TYPE != null)
                        {
                            QualificationDetails.EXAM_DEGREE_TYPE = QualificationDetailsEntities.EXAM_DEGREE_TYPE;
                        }
                        if (QualificationDetailsEntities.SUBJECT != "" && QualificationDetailsEntities.SUBJECT != null)
                        {
                            QualificationDetails.SUBJECT = QualificationDetailsEntities.SUBJECT;
                        }

                        if (QualificationDetailsEntities.TOTAL_MARKS != null)
                        {
                            QualificationDetails.TOTAL_MARKS = QualificationDetailsEntities.TOTAL_MARKS;
                        }
                        if (QualificationDetailsEntities.MARKS_SECURED != null)
                        {
                            QualificationDetails.MARKS_SECURED = QualificationDetailsEntities.MARKS_SECURED;
                        }
                        if (QualificationDetailsEntities.PERCENTAGE_OF_MARK_DIVISION != null)
                        {
                            QualificationDetails.PERCENTAGE_OF_MARK_DIVISION = QualificationDetailsEntities.PERCENTAGE_OF_MARK_DIVISION;
                        }

                        _UOW.EMP_QUALIFICATION_DETAILSRepository.Update(QualificationDetails);
                        _UOW.Save();
                    }
               
            }
            return success;
        }

        public bool DeleteQualificationDetails(int QualificationDetailsId)
        {
            throw new NotImplementedException();
        }
    }
}
