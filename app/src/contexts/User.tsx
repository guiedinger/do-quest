import React, {
  createContext,
  useCallback,
  useEffect,
  useMemo,
  useState,
} from "react";

export interface IUser {
  login: string;
  senha: string;
  nome: string;
  sobrenome: string;
  dataNascimento: Date;
  grupoUsuario?: any;
  respondeuAoQuestionario: boolean;
  isAdmin: boolean;
  id: string;
}

export interface IUserContext {
  user: IUser | null;
  signIn: (user: IUser) => void;
  signOut: () => void;
  isSigned: () => boolean;
}

const UserContext = createContext<IUserContext>({} as IUserContext);

type Props = {
  children?: React.ReactNode;
};

export const UserProvider: React.FC<Props> = ({ children }) => {
  const [user, setUser] = useState<IUser | null>(null);

  const signIn = useCallback((localUser: IUser) => {
    localStorage.setItem("user", JSON.stringify(localUser));
    setUser(localUser);
  }, []);

  const signOut = useCallback(() => {
    localStorage.removeItem("user");
    setUser(null);
  }, []);

  const isSigned = useCallback(() => {
    const localUser = localStorage.getItem("user");
    if (localUser) {
      setUser(JSON.parse(localUser));
      return true;
    }
    return false;
  }, []);

  useEffect(() => {
    isSigned();
  }, []);

  const contextValue = useMemo(
    (): IUserContext => ({
      user,
      signIn,
      signOut,
      isSigned,
    }),
    [user]
  );

  return (
    <UserContext.Provider value={contextValue}>{children}</UserContext.Provider>
  );
};

export default UserContext;
