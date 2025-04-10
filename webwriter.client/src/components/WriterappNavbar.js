import React from 'react';
import { Navbar, NavbarBrand, NavItem, NavLink } from 'reactstrap';


export function WriterappNavbar() {
    const openOptions = () => {
        chrome.runtime.openOptionsPage();
    }

    return (
        <Navbar
            className="mb-2"
            color="dark"
            dark
        >
            <NavbarBrand>
                <img
                    alt="logo"
                    src="wa-logo.png"
                    style={{
                        height: 40,
                        width: 40
                    }}
                />
            </NavbarBrand>
            <NavItem className="mr-auto">
                <NavLink href={openOptions} className='text-light'>
                    Options
                </NavLink>
            </NavItem>
        </Navbar>
    );
}