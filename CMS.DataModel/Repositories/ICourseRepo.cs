using System.Threading.Tasks;

namespace CMS.DataModel.Repositories
{
    public interface ICourseRepo : IRepository<Course>
    {
        Task<Course> Delete(int courseId);
    }
}
