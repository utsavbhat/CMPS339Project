import React, { Component } from 'react';
import axios from 'axios';

export default class App extends Component {
    static displayName = App.name;
    constructor(props) {
        super(props);

        this.state = { users: [], loading: true, showForm: false, };
    }

    componentDidMount() {
        this.loadUserTable();
    }

    renderUsers(users) {
        return (
            <div className="container">
                <div className="row">
                    <div className="col-6">
                        <table className='table table-striped' aria-labelledby="tabelLabel">
                            <thead>
                                <tr>
                                    <th>User</th>
                                </tr>
                            </thead>
                            <tbody>
                                {users.map(user =>
                                    <tr key={user.id}>
                                        <td>{user.username}</td>
                                        <td className="d-flex justify-content-end">
                                            <button type="button"
                                                className="btn btn-danger"
                                                onClick={this.handleClick.bind(this, user.id)}>Delete</button>
                                        </td>
                                    </tr>
                                )}
                            </tbody>
                        </table>

                    </div>
                </div>
            </div>
        );
    }

    handleClick = (id) => {
        this.deleteUser(id);
    };    

    render() {
        let userTable = this.renderUsers(this.state.users);

        return (

            <div className="container">
                <h1>Active Users</h1>
                {userTable}
            </div>
        );
    }

    loadUserTable() {

        var base_URL = "https://localhost:7144";
        var self = this;

        return axios.get(base_URL + '/Users/GetUsers')
            .then(function (response) {
                self.setState({ users: response.data, loading: false });
            })
            .catch(function (error) {
                // handle error
                console.log(error);
            })
            .finally(function () {
                // always executed
            });
    }

    deleteUser(ID) {
        var base_URL = "https://localhost:7144";
        var self = this;

        return axios.get(base_URL + '/Users/DeleteUser', {
            params: {
                id: ID
            }
        })
            .then(function (response) {
                self.loadUserTable();
            })
            .catch(function (error) {
                // handle error
                console.log(error);
            })
            .finally(function () {
                // always executed
            });
    }
}