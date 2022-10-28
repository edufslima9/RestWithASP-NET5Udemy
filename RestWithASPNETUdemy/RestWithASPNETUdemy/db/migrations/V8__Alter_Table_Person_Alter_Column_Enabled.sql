ALTER TABLE public.person
    ALTER enabled DROP DEFAULT,
    ALTER enabled TYPE bool USING (enabled::int::bool),
    ALTER enabled SET NOT NULL,
    ALTER enabled SET DEFAULT true;