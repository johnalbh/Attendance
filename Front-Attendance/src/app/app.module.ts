import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { NotFoundComponent } from './error-pages/not-found/not-found.component';
import { Routing } from './app.routing';
import { EnvironmentUrlService } from './shared/services/environment-url.service';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RepositoryService } from './shared/services/repository.service';
import { InternalServerComponent } from './error-pages/internal-server/internal-server.component';
import { ErrorHandlerService } from './shared/services/error-handler.service';
import { FormsModule} from '@angular/forms';
import { UserService } from './shared/services/user.service';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ReactiveFormsModule } from '@angular/forms';
import { AuthInterceptor } from './auth/auth.interceptor';
import { ForbiddenComponent } from './forbidden/forbidden.component';


@NgModule({
  declarations: [
    AppComponent,
    NotFoundComponent,
    InternalServerComponent,
    ForbiddenComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    Routing,
    FormsModule,
    HttpClientModule,
    ToastrModule.forRoot(),
    BrowserAnimationsModule,
    ReactiveFormsModule,

  ],
  providers: [EnvironmentUrlService, RepositoryService, ErrorHandlerService, UserService, {
    provide: HTTP_INTERCEPTORS,
    useClass: AuthInterceptor,
    multi: true
  }],

  bootstrap: [AppComponent]
})
export class AppModule { }
