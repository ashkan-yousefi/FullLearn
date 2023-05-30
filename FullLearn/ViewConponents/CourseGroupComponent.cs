using FullLearn.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FullLearn.Web.ViewConponents
{
    public class CourseGroupComponent: ViewComponent
    {
        private readonly ICourseService _courseService;

        public CourseGroupComponent(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult)View("CourseGroup",_courseService.GetAllGroup()));
        }
    }
}
