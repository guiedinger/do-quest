import {
  BrowserRouter as Router,
  Routes as Switch,
  Route,
} from "react-router-dom";
import { Login } from "./pages/Login";
import { Questionario } from "./pages/Questionario";
import { Questionarios } from "./pages/Questionarios";

export const Routes = () => {
  return (
    <Router>
      <Switch>
        <Route path="/" element={<Questionarios />} />
        <Route path="/questionario" element={<Questionario />} />
        <Route path="/login" element={<Login />} />
      </Switch>
    </Router>
  );
};
