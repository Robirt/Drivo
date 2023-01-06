import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdsComponent } from './ads/ads/ads.component';
import { CalendarComponent } from './calendar/calendar/calendar.component';
import { IsAuthenticatedGuard } from './guards/is-authenticated.guard';
import { IsInRoleGuard } from './guards/is-in-role.guard';
import { HomeComponent } from './home/home.component';
import { InstructorsComponent } from './instructors/instructors/instructors.component';
import { LecturerComponent } from './lecturers/lecturer/lecturer.component';
import { LecturersComponent } from './lecturers/lecturers/lecturers.component';
import { PaymentsComponent } from './payments/payments/payments.component';
import { SignInComponent } from './sign-in/sign-in.component';
import { SignOutComponent } from './sign-out/sign-out.component';
import { StudentsComponent } from './students/students/students.component';
import { StudyComponent } from './study/study/study.component';
import { UnauthorizedComponent } from './unauthorized/unauthorized.component';

const routes: Routes = [
  { component: HomeComponent, path: "", canActivate: [IsAuthenticatedGuard] },
  { component: StudyComponent, path: "Study", canActivate: [IsInRoleGuard], data: { roles: ['Lecturer'] } },
  { component: SignInComponent, path: "SignIn" },
  { component: StudentsComponent, path: "Students", canActivate: [IsAuthenticatedGuard] },
  { component: InstructorsComponent, path: "Instructors", canActivate: [IsAuthenticatedGuard] },
  { component: LecturersComponent, path: "Lecturers", canActivate: [IsAuthenticatedGuard] },
  { component: LecturerComponent, path: "Lecturers/:userName", canActivate: [IsAuthenticatedGuard, IsInRoleGuard], data: { roles: ['Administrator'] } },
  { component: AdsComponent, path: "Ads", canActivate: [IsAuthenticatedGuard] },
  { component: CalendarComponent, path: "Calendar", canActivate: [IsAuthenticatedGuard]},
  { component: PaymentsComponent, path: "Payments", canActivate: [IsInRoleGuard, IsAuthenticatedGuard], data: { roles: ['Administrator'] } }, 
  { component: UnauthorizedComponent, path: "Unauthorized" },
  { component: SignOutComponent, path: "SignOut" }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
