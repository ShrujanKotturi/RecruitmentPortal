using System;
using System.Data;
using RPDataAccessLayer;

namespace RPBusinessLogicLayer
{
    public class InterviewSchedulingBLL
    {
        InterviewSchedulingDAL interviewSchedulingObject = new InterviewSchedulingDAL();
        public DataTable ShowApplicantsDetails(long recruiterLiginId)
        {
            return interviewSchedulingObject.ShowApplicantsDetails(recruiterLiginId);
        }

        public int UpdateApplication(string candidateName, int postId, char interviewStatus, DateTime interviewDatetime)
        {
            return interviewSchedulingObject.UpdateApplication(candidateName, postId, interviewStatus, interviewDatetime);
        }

        public int UpdateUnscheduledApplication(string candidateName, int postId, char interviewStatus)
        {
            return interviewSchedulingObject.UpdateUnscheduledApplication(candidateName, postId, interviewStatus);
        }

        public DataTable JobSeekerDetails(string candidateName)
        {
            return interviewSchedulingObject.JobSeekerDetails(candidateName);
        }

        public DataTable GetRecruiterUserName(int loginId)
        {
            return interviewSchedulingObject.GetRecruiterUserName(loginId);
        }

        public DataTable GetResumePathOfCandidate(string candidateName)
        {
            return interviewSchedulingObject.GetResumePathOfCandidate(candidateName);
        }
    }
}
