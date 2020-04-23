import React, { Component } from 'react';
import authService from './api-authorization/AuthorizeService'
import { Button } from '@material-ui/core'

export class Home extends Component {
    constructor(props) {
        super(props);

        this.state = {
            model: {
                userId: '',
                description: '',
                website: '',
                userName: '',
                categories: '',
                reviews: ''
            }
        }
    }

    async getData() {
        const token = await authService.getAccessToken();
        var response = await fetch('admin', {
            headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
        });

        var json = await response.json();
        console.log(json);
    }

    componentDidMount() {
        this.getData();
    }

    render() {
        const { userName, description } = this.state.model;

        return (
            <div>
                <div>
                    Hello {userName}
                </div>
                <Button color="primary">hello helo</Button>
                <div>
                    Description {description}
                </div>
            </div>
        );
    }
}
