import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SignInComponent } from './sign-in/sign-in.component';
import { HomeComponent } from './home/home.component';
import { HeaderComponent } from './header/header.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { StudyModule } from './study/study.module';
import { FooterComponent } from './footer/footer.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { StudentsModule } from './students/students.module';
import { InstructorsModule } from './instructors/instructors.module';
import { LecturersModule } from './lecturers/lecturers.module';

import { CalendarPageModule } from './calendar/calendar.module';
import { JwtBearerTokenInterceptor } from 'src/jwtBearerToken.interceptor';
import { UnauthorizedComponent } from './unauthorized/unauthorized.component';
import { SignOutComponent } from './sign-out/sign-out.component';
import { AdsModule } from './ads/ads.module';
import { StudentsGroupsModule } from './students-groups/students-groups.module';
import { PaymentsModule } from './payments/payments.module';



@NgModule({
  declarations: [
    AppComponent,
    SignInComponent,
    HomeComponent,
    HeaderComponent,
    NavMenuComponent,
    FooterComponent,
    UnauthorizedComponent,
    SignOutComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
      AppRoutingModule,
      HttpClientModule,
      FormsModule,
      StudyModule,
      StudentsModule,
      InstructorsModule,
      LecturersModule,
      AdsModule,
      CalendarPageModule,
      StudentsGroupsModule,
      PaymentsModule
  ],
  providers: [{ provide: HTTP_INTERCEPTORS, useClass: JwtBearerTokenInterceptor, multi: true }],
  bootstrap: [
    AppComponent
  ]
})
export class AppModule { }
