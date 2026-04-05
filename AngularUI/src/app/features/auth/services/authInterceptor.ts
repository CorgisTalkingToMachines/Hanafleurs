import { HttpInterceptorFn } from '@angular/common/http';

export const authInterceptor: HttpInterceptorFn = (request, next) => {
  const cloned = request.clone({ withCredentials: true });
  return next(cloned);
};
