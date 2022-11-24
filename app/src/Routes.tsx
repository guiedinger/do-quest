import {
  BrowserRouter as Router,
  Routes as Switch,
  Route,
  Navigate,
} from "react-router-dom";
import useUser from "./hooks/useUser";
import { Login } from "./pages/Login";
import { QuestionarioUsuario } from "./pages/QuestionarioUsuario";
import { QuestionariosUsuario } from "./pages/QuestionariosUsuario";
import { Usuario } from "./pages/Usuario";
import { Usuarios } from "./pages/Usuarios";
import { HomeAdmin } from "./pages/HomeAdmin";
import { QuestionariosAdmin } from "./pages/QuestionariosAdmin";
import { QuestionarioAdmin } from "./pages/QuestionarioAdmin";

export const Routes = () => {
  const { user } = useUser();

  return (
    <Router>
      <Switch>
        {user ? (
          user.isAdmin ? (
            <>
              <Route path="/" element={<HomeAdmin />} />
              <Route path="/usuarios" element={<Usuarios />} />
              <Route path="/usuario" element={<Usuario />} />
              <Route path="/questionarios" element={<QuestionariosAdmin />} />
              <Route path="/questionario" element={<QuestionarioAdmin />} />
              <Route path="*" element={<Navigate to="/" />} />
            </>
          ) : (
            <>
              <Route path="/" element={<QuestionariosUsuario />} />
              <Route path="/questionario" element={<QuestionarioUsuario />} />
              <Route path="*" element={<Navigate to="/" />} />
            </>
          )
        ) : (
          <>
            <Route path="/" element={<Login />} />
            <Route path="*" element={<Navigate to="/" />} />
          </>
        )}
      </Switch>
    </Router>
  );
};
