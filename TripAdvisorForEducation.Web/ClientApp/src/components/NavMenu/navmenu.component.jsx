import React, { Component, useState } from "react";
import { Link } from "react-router-dom";
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink, DropdownMenu, Dropdown, DropdownToggle, DropdownItem } from 'reactstrap';
import { ReactComponent as Logo } from "../../assets/EdTech.svg";
import { LoginMenu } from '../api-authorization/LoginMenu';
import "./navmenu.style.css";




export class NavMenu extends Component {
  static displayName = NavMenu.name;

  constructor (props) {
    super(props);

    this.toggleNavbar = this.toggleNavbar.bind(this);
    this.state = {
      collapsed: true
    };
  }

  toggleNavbar () {
    this.setState({
      collapsed: !this.state.collapsed
    });
  }

  render () {
   
    return (
      <header>
        <Navbar className="navbar-expand-sm navbar-toggleable-sm light  " light style={{backgroundColor: '#414282',fontSize: 20 }} >
          <Container>
            <NavbarBrand tag={Link} style={{fontSize: 40 , color: 'white'}} to="/">EdTech</NavbarBrand>
            <NavbarToggler onClick={this.toggleNavbar} className="mr-2" />
            <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={!this.state.collapsed} navbar>
              <ul className="navbar-nav flex-grow">
                <NavItem>
                  <DropDownCategories />
                </NavItem>
                <NavItem>
                  <NavLink tag={Link}  style={{color: 'white'}} to="/for-companies">For Companies</NavLink>
                </NavItem>
                <LoginMenu>
                </LoginMenu>
              </ul>
            </Collapse>
          </Container>
        </Navbar>
      </header>
    );
  }
}

export default NavMenu;


function DropDownCategories (props){

  const [dropdownOpen, setDropdownOpen] = useState(false);
  const toggle = () => setDropdownOpen(!dropdownOpen);  

  return(

    <Dropdown  nav group={true} isOpen={dropdownOpen} toggle={toggle}>
      <DropdownToggle nav caret style={{color: 'white'}}>
        Categories
      </DropdownToggle>
      <DropdownMenu>
        <DropdownItem>Assistance </DropdownItem>
        <DropdownItem>Feedback tools</DropdownItem>
        <DropdownItem >Communication</DropdownItem>
        <DropdownItem>Task Managment</DropdownItem>
        <DropdownItem>Schedule</DropdownItem>
        <DropdownItem>Presentation</DropdownItem>
        <DropdownItem>Peer Feedback</DropdownItem>
      </DropdownMenu>

    </Dropdown>

  );

}

