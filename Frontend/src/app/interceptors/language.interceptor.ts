import { Injectable } from "@angular/core";
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from "@angular/common/http";
import { Observable } from "rxjs";

@Injectable()
export  class LanguageInterceptor implements HttpInterceptor {
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const language = localStorage.getItem('selectedLanguage') || 'en';
    req = req.clone({
      setHeaders: {
        'Accept-Language': language,
        'Content-Language': language
      }
    });
    return next.handle(req);
  }
}
