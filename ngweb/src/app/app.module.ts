import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './modules/app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './pages/login/login.component';
import { SharedModule } from './modules/shared.module';
import { HomeComponent } from './pages/home/home.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { JwtModule, JWT_OPTIONS } from '@auth0/angular-jwt';
import { UserComponent } from './pages/user/user.component';
import { ChannelComponent } from './components/channel/channel.component';
import { NavigationComponent } from './components/navigation/navigation.component';
import { AuthService } from './services/auth.service';
import { ChannelsService } from './services/channels.service';
import { CategoryComponent } from './components/category/category.component';
import { DetailsComponent } from './pages/details/details.component';
import { ReviewsComponent } from './components/reviews/reviews.component';
import { ReviewComponent } from './components/reviews/review/review.component';

export function getToken() {
  let token = localStorage.getItem('token');
  return token;
}

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    HomeComponent,
    NavbarComponent,
    UserComponent,
    ChannelComponent,
    NavigationComponent,
    CategoryComponent,
    DetailsComponent,
    ReviewsComponent,
    ReviewComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: getToken,
        whitelistedDomains: ['localhost:63472']
      }
    }),
    ReactiveFormsModule,
    AppRoutingModule,
    SharedModule
  ],
  providers: [AuthService, ChannelsService],
  bootstrap: [AppComponent]
})
export class AppModule { }
