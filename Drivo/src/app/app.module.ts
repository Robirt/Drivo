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
import { HttpClientModule } from '@angular/common/http';
import { StudentModule } from './student/student.module';
import { InstructorModule } from './instructor/instructor.module';
import { LecturerModule } from './lecturer/lecturer.module';
import { AdModule } from './ad/ad.module';
import { CalendarPageModule } from './calendar/calendar.module';
import { ResourcesModule } from './resources/resources.module';



@NgModule({
  declarations: [
    AppComponent,
    SignInComponent,
    HomeComponent,
    HeaderComponent,
    NavMenuComponent,
    FooterComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
      AppRoutingModule,
      HttpClientModule,
      FormsModule,
      StudyModule,
      StudentModule,
      InstructorModule,
      LecturerModule,
      AdModule,
      CalendarPageModule,
      ResourcesModule
  ],
  providers: [],
  bootstrap: [
    AppComponent
  ]
})
export class AppModule { }
