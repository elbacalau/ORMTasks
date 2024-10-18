import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { provideRouter, RouterModule } from '@angular/router';
import { routes } from './app.routes';
import { HTTP_INTERCEPTORS, HttpClient, HttpClientModule, HttpInterceptor } from '@angular/common/http';
import { AuthInterceptor } from './services/user_services/auth.interceptor';

@NgModule({
  declarations: [
    AppComponent,
     // Declara el componente aquí
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(routes),
    HttpClientModule
  ],
  providers: [
    provideRouter(routes),
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
