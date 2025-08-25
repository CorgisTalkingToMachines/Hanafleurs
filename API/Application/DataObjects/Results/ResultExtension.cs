using Microsoft.AspNetCore.Mvc;

namespace API.Application.DataObjects.Results
{
    public static class ResultExtension
    {
        public static ActionResult ToActionResult<T>(this IResult<T> result, ControllerBase controller)
        {
            if (result.IsSuccess)
                return controller.Ok(result);

            return result.ErrorType switch
            {
                ErrorType.NotFound => controller.NotFound(result),
                ErrorType.Unauthorized => controller.Unauthorized(result),
                ErrorType.BadRequest => controller.BadRequest(result),
                _ => throw new NotImplementedException(),
            };
        }
    }
}
