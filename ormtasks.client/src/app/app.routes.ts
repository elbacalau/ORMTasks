import { Route, Routes } from "@angular/router";
import { LoginComponentComponent } from "./pages/login_screen/login-component/login-component.component";
import { RegisterComponent } from "./pages/register_screen/register-component/register-component.component";
import { HomeScreenComponent } from "./pages/home_screen/home-screen/home-screen.component";
import { DashboardComponent } from "./pages/home_screen/dashboard/dashboard.component";
import { authGuard } from "./guards/auth.guard";

export const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: 'login', component: LoginComponentComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'dashboard', component: DashboardComponent, canActivate: [authGuard] },
  { path: 'home', component: HomeScreenComponent },
  { path: "**", loadComponent: () => import('./pages/components/not-found/not-found.component').then(comp => comp.NotFoundComponent) }
];
