import React, { Component } from 'react';
import { Route } from 'react-router';
import AuthorizeRoute from './components/api-authorization/AuthorizeRoute';
import ApiAuthorizationRoutes from './components/api-authorization/ApiAuthorizationRoutes';
import { ApplicationPaths } from './components/api-authorization/ApiAuthorizationConstants';

import './custom.css';

export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
      <div>
        <Route
          path={ApplicationPaths.ApiAuthorizationPrefix}
          component={ApiAuthorizationRoutes}
        />
        <h1>Hello wolrddds</h1>
      </div>
    );
  }
}
