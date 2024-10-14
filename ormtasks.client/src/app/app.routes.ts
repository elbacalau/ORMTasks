import { Route, Routes } from "@angular/router";
import { LoginComponentComponent } from "./pages/login_screen/login-component/login-component.component";
import { RegisterComponent } from "./pages/register_screen/register-component/register-component.component";

export const routes: Routes = [
  { path: '', redirectTo: 'login', pathMatch: 'full' },
  { path: 'login', component: LoginComponentComponent },
  { path: 'register', component: RegisterComponent }
];
