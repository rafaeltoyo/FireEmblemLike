import React, { Component } from 'react';
import './App.css';

import Alert from 'react-bootstrap/Alert';

import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import NavbarBrand from 'react-bootstrap/NavbarBrand';
import NavbarCollapse from 'react-bootstrap/NavbarCollapse';
import NavbarToggle from 'react-bootstrap/NavbarToggle';
import NavItem from 'react-bootstrap/NavItem';
import NavLink from 'react-bootstrap/NavLink';

export default class App extends Component {
    render() {
        return (
            <Navbar bg="dark" variant="dark" expand="sm">

                <NavbarBrand>Jogo teste</NavbarBrand>
                <NavbarToggle />

                <NavbarCollapse>
                    <Nav>
                        <NavItem>
                            <NavLink active>Home</NavLink>
                        </NavItem>
                        <NavItem>
                            <NavLink active>About</NavLink>
                        </NavItem>
                        <NavItem>
                            <NavLink active>Register</NavLink>
                        </NavItem>
                    </Nav>
                </NavbarCollapse>

            </Navbar>
        );
    };
}
