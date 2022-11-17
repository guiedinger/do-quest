import {
  BrowserRouter as Router,
  Routes as Switch,
  Route,
} from "react-router-dom";
import useUser from "./hooks/useUser";
import { Login } from "./pages/Login";
import { Questionario } from "./pages/Questionario";
import { Questionarios } from "./pages/Questionarios";
import { Usuarios } from "./pages/Usuarios";

export const Routes = () => {
  const { user } = useUser();

  return (
    <Router>
      <Switch>
        {user ? (
          user.isAdmin ? (
            <>
              <Route path="/" element={<Usuarios />} />
            </>
          ) : (
            <>
              <Route path="/" element={<Questionarios />} />
              <Route path="/questionario" element={<Questionario />} />
            </>
          )
        ) : (
          <Route path="/" element={<Login />} />
        )}
      </Switch>
    </Router>
  );
};
