import React, { Component } from "react";
import { Container } from "reactstrap";
<<<<<<< HEAD
import NavMenu from "../NavMenu/navmenu.component";
=======
import  NavMenu  from "../NavMenu/navmenu.component";
>>>>>>> react

export default class Layout extends Component {
  render() {
    return (
      <div>
        <NavMenu />
<<<<<<< HEAD
        <div>
          {this.props.children}
        </div>
=======
        <Container>{this.props.children}</Container>
>>>>>>> react
      </div>
    );
  }
}
