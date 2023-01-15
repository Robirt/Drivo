import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdsComponent } from './ads/ads/ads.component';
import { CalendarComponent } from './calendar/calendar/calendar.component';
import { IsAuthenticatedGuard } from './guards/is-authenticated.guard';
import { IsInRoleGuard } from './guards/is-in-role.guard';
import { HomeComponent } from './home/home.component';
import { InstructorComponent } from './instructors/instructor/instructor.component';
import { InstructorsComponent } from './instructors/instructors/instructors.component';
import { LecturerComponent } from './lecturers/lecturer/lecturer.component';
import { LecturersComponent } from './lecturers/lecturers/lecturers.component';
import { PaymentsComponent } from './payments/payments/payments.component';
import { SignInComponent } from './sign-in/sign-in.component';
import { SignOutComponent } from './sign-out/sign-out.component';
import { StudentsGroupsComponent } from './students-groups/students-groups/students-groups.component';
import { StudentComponent } from './students/student/student.component';
import { StudentsComponent } from './students/students/students.component';
import { CourseModuleComponent } from './study/course-module/course-module.component';
import { StudyComponent } from './study/study/study.component';
import { UnauthorizedComponent } from './unauthorized/unauthorized.component';

const routes: Routes = [
  { component: HomeComponent, path: "" },
  { component: StudyComponent, path: "Study", canActivate: [IsAuthenticatedGuard], data: { roles: ['Lecturer'] } },
  { component: CourseModuleComponent, path: "Study/:courseModuleName", canActivate: [IsAuthenticatedGuard] },
  { component: SignInComponent, path: "SignIn" },
  { component: StudentsComponent, path: "Students", canActivate: [IsInRoleGuard], data: { roles: ['Administrator'] } },
  { component: StudentComponent, path: "Students/:userName", canActivate: [IsInRoleGuard], data: { roles: ['Administrator'] } },
  { component: StudentsGroupsComponent, path: "StudentsGroups", canActivate: [IsInRoleGuard], data: { roles: ['Administrator'] } },
  { component: InstructorsComponent, path: "Instructors", canActivate: [IsInRoleGuard], data: { roles: ['Administrator'] } },
  { component: InstructorComponent, path: "Instructors/:userName", canActivate: [IsInRoleGuard], data: { roles: ['Administrator'] } },
  { component: LecturersComponent, path: "Lecturers", canActivate: [IsInRoleGuard], data: { roles: ['Administrator'] }  },
  { component: LecturerComponent, path: "Lecturers/:userName", canActivate: [IsInRoleGuard], data: { roles: ['Administrator'] } },
  { component: AdsComponent, path: "Ads", canActivate: [IsAuthenticatedGuard] },
  { component: CalendarComponent, path: "Calendar", canActivate: [IsInRoleGuard], data: { roles: ['Lecturer', 'Instructor'] }},
  { component: PaymentsComponent, path: "Payments", canActivate: [IsInRoleGuard, IsAuthenticatedGuard], data: { roles: ['Administrator'] } }, 
  { component: UnauthorizedComponent, path: "Unauthorized" },
  { component: SignOutComponent, path: "SignOut" }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
