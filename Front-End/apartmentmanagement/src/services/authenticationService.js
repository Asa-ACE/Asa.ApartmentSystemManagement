import { createContext, useState } from "react";



export const AuthContext = createContext()

function AuthenticationService(props){
    const [isLoggedIn, setIsLoggedIn] = useState(false);

    const {children} = props;
    return (
        <AuthContext.Provider value={{loggedIn}}>
            {children}
        </AuthContext.Provider>
    )
}

export default AuthenticationService;