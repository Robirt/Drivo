import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdComponent } from './ad/ad/ad.component';
import { CalendarComponent } from './calendar/calendar/calendar.component';
import { HomeComponent } from './home/home.component';
import { InstructorComponent } from './instructor/instructor/instructor.component';
import { LecturerComponent } from './lecturer/lecturer/lecturer.component';
import { SignInComponent } from './sign-in/sign-in.component';
import { StudentComponent } from './student/student/student.component';
import { StudyComponent } from './study/study/study.component';

const routes: Routes = [
  { component: HomeComponent, path:""},
  { component: StudyComponent, path:"study"},
  { component: SignInComponent, path: "SignIn" },
  { component:StudentComponent, path:"Student"},
  { component:InstructorComponent, path:"Instructor"},
  { component:LecturerComponent, path:"Lecturer"},
  { component:AdComponent, path:"Ad"},
  { component:CalendarComponent, path:"Calendar"}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
