import React, { Component } from 'react';
import { Route } from 'react-router';
import AuthorizeRoute from './components/api-authorization/AuthorizeRoute';
import ApiAuthorizationRoutes from './components/api-authorization/ApiAuthorizationRoutes';
import { ApplicationPaths } from './components/api-authorization/ApiAuthorizationConstants';
import Layout from './components/Layout/Layout';
import Home from './pages/Home/Home';

//Pages
import ForCompanies from './pages/For_Companies/For_companies';

import './custom.css';

export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
      <Layout>
        <Route path='/for-companies' component={ForCompanies} />
        <Route
          path={ApplicationPaths.ApiAuthorizationPrefix}
          component={ApiAuthorizationRoutes}
        />
        <Route path='/' component={Home} />
      </Layout>
    );
  }
}
